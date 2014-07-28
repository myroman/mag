function SalesVm(model) {
  var it = this;

  var saleItem = function(plainData) {
    this.id = 0;
    this.reportCode = ko.observable();
    this.create = ko.observable();
    this.agent = ko.observable();
    this.update(plainData);
  };
  ko.utils.extend(saleItem.prototype, {
    update: function(data) {
      this.id = data.id;
      this.reportCode(data.reportCode);
      this.create(data.create);
      this.agent({
        id: data.agent.id,
        name: data.agent.name
      });
    }
  });
  
  it.items = ko.observableArray(ko.utils.arrayMap(model.sales, function(data) {
    return new saleItem(data);
  }));
  
  it.editedSaleData = {
    agent: {
    },
    insurance: {
      id: 1,
      name: 'каско'
    },
    reportCode: ko.observable(''),
    create: ko.observable('')
  };
  
  it.editedAgent = ko.observable();
  
  function clearSale(x) {
    x.reportCode(null);
    x.create(null);
  }

  clearSale(it.editedSaleData);

  it.saveNewItem = function () {
    var copy = ko.toJS(it.editedSaleData);
    copy.agent = ko.toJS(it.editedAgent);

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
      }
    });
  };

  it.agents = ko.observableArray(model.agents);
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