function SalesVm(model) {
  console.log(model);
  var it = this;

  var saleItem = function(plainData) {
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
    this.fee = ko.observable();
    this.comment = ko.observable();
    this.addFeePc = ko.observable();
    this.addFee = ko.observable();

    this.update(plainData);
  };
  ko.utils.extend(saleItem.prototype, {
    update: function(data) {
      this.id = data.id;
      this.reportCode(data.reportCode);
      this.create(data.create);
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
      this.fee(data.fee);
      this.comment(data.comment);
      this.addFeePc(data.addFeePc);
      this.addFee(data.addFee);
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
    premium: ko.observable(),
    paymentsNumber: ko.observable(),
    paidSum: ko.observable(),
    feePc: ko.observable(),
    fee: ko.observable(),
    comment: ko.observable(),
    addFeePc: ko.observable(),
    addFee: ko.observable(),
  };
  
  it.editedAgent = ko.observable();
  it.editedInsurance = ko.observable();
  it.isAdminNow = model.isAdminNow;

  function clearSale(x) {
    x.reportCode(null);
    x.create(null);
  }

  clearSale(it.editedSaleData);

  it.saveNewItem = function () {
    var copy = ko.toJS(it.editedSaleData);
    copy.agent = ko.toJS(it.editedAgent);
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
        it.editedAgent(null);
        it.editedInsurance(null);
      }
    });
  };

  it.agents = ko.observableArray(model.agents);
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
    
    ko.bindingHandlers.datepicker = {
      init: function(element, valueAccessor, allBindings, viewModel, bindingContext) {
        if (ko.unwrap(valueAccessor())) {
          $(element).datepicker();
        }
      },
      update: function(element, valueAccessor, allBindings, viewModel, bindingContext) {
      }
    };

    var model = $('.b-sales').data('model');
    ko.applyBindings(new SalesVm(model));
  }
});