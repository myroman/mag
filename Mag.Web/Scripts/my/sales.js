function SalesVm(model) {
  var it = this;

  var saleItem = function (plainData) {
    var that = this;
    
    this.id = 0;
    this.checked = ko.observable();
    this.reportCode = ko.observable();
    this.create = ko.observable();
    this.agent = ko.observable();
    this.insurance = ko.observable();
    this.contractsNumber = ko.observable();
    this.premium = ko.observable();
    this.paymentsNumber = ko.observable();
    this.paidSum = ko.observable();
    this.feePc = ko.observable();
    this.fee = ko.computed(function () {
      return that.premium() * that.feePc() / 100;
    });
    this.comment = ko.observable();
    this.addFeePc = ko.observable();
    this.addFee = ko.computed(function() {
      return that.premium() * that.addFeePc() / 100;
    });

    this.update(plainData);
  };

  ko.utils.extend(saleItem.prototype, {
    update: function(data) {
      this.id = data.id;
      this.reportCode(data.reportCode);
      this.create = data.createFormatted;
      this.agent({
        id: data.agent.id,
        fullName: data.agent.fullName
      });
      this.insurance({
        id: data.insurance.id,
        name: data.insurance.name
      });
      this.contractsNumber(data.contractsNumber);
      this.premium(data.premium);
      this.paymentsNumber(data.paymentsNumber);
      this.paidSum(data.paidSum);
      this.feePc(data.feePc);
      this.comment(data.comment);
      this.addFeePc(data.addFeePc);
      this.checked(data.checked);
    }
  });
  
  it.items = ko.observableArray(ko.utils.arrayMap(model.sales, function(data) {
    return new saleItem(data);
  }));

  it.editedSaleData = {
    agent: {
    },
    insurance: {
    },
    reportCode: ko.observable(''),
    create: ko.observable(''),
    checked: false,
    contractsNumber: ko.observable(),
    premium: ko.observable(0),
    paymentsNumber: ko.observable(0),
    paidSum: ko.observable(0),
    feePc: ko.observable(0),
    comment: ko.observable(''),
    addFeePc: ko.observable(0)
  };
  it.editedSaleData.fee = ko.computed(function() {
    return it.editedSaleData.premium() * it.editedSaleData.feePc() / 100;
  });
  it.editedSaleData.addFee = ko.computed(function() {
    return it.editedSaleData.premium() * it.editedSaleData.addFeePc() / 100;
  });

  it.currentUser = model.currentUser;
  it.isAdminNow = it.currentUser.isAdmin;

  it.editedInsurance = ko.observable();
  
  function clearSale(x) {
    x.reportCode(null);
    x.create(null);
  }

  clearSale(it.editedSaleData);

  it.saveNewItem = function () {
    var copy = ko.toJS(it.editedSaleData);
    copy.agent = ko.toJS(it.currentUser);
    copy.insurance = ko.toJS(it.editedInsurance);

    $.ajax('/ApiHandler.axd', {
      data: {
        entity: 'sale',
        action: 'add',
        object: ko.toJSON(copy)
      },
      type: 'POST',
      dataType: 'json',
      success: function (resp) {
        it.items.push(new saleItem(resp));

        clearSale(it.editedSaleData);
        it.editedInsurance(null);
      }
    });
  };

  it.insuranceTypes = ko.observableArray(model.insuranceTypes);

  // Selecting
  it.getSelected = function () {
    var res = $.map(it.items(), function (x) {
      return x.checked() ? x : null;
    });
    return res;
  };

  it.hasCheckedItems = ko.computed(function () {
    return it.getSelected().length > 0;
  });

  it.getClassForDelete = ko.computed(function () {
    return it.hasCheckedItems() ? '' : 'disabled';
  });
  it.deleteSelected = function () {
    var ids = $.map(it.getSelected(), function(x) { return x.id; });
    $.ajax('/ApiHandler.axd', {
      data: {
        entity: 'sale',
        action: 'delete',
        ids: ko.toJSON(ids)
      },
      type: 'POST',
      dataType: 'json',
      success: function (resp) {
        $.each(resp, function(i, val) {
          it.items.remove(function(x) {
             return x.id == val;
          });
        });
      }
    });
  };
}

$(function() {
  if ($('.b-sales').length > 0) {
    var model = $('.b-sales').data('model');
    ko.applyBindings(new SalesVm(model));
  }
});