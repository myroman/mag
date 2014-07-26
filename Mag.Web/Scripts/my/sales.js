function SalesVm(model) {
  var it = this;

  it.items = ko.observableArray(model.sales);
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
  
  it.editedAgent = ko.observable({
    id: 0,
    name: ''
  });
  
  function clearSale(x) {
    x.reportCode('');
    x.create('');
  }

  clearSale(it.editedSaleData);

  it.saveNewItem = function () {
    var copy = ko.toJS(it.editedSaleData);
    copy.agent = {
      id: it.editedAgent().id,
      name: it.editedAgent().name
    };

    $.ajax('/ApiHandler.axd', {
      data: {
        entity: 'sale',
        action: 'add',
        object: ko.toJSON(copy)
      },
      type: 'POST',
      dataType: 'json',
      success: function(resp) {
        it.items.push(resp);
        clearSale(it.editedSaleData);
        it.editedAgent().id = 0;
        it.editedAgent().name = 0;
      }
    });
  };

  it.agents = ko.observableArray(model.agents);
}

$(function() {
  if ($('.b-sales').length >= 0) {
    
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