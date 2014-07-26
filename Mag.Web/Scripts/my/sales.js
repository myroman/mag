function SalesVm(model) {
  var it = this;

  it.items = ko.observableArray(model);
  it.editedSaleData = {
    id: 132,
    agent: {
      id: 1,
      name: ko.observable('')
    },
    insurance: {
      id: 1,
      name: 'каско'
    },
    reportCode: ko.observable(''),
    create: ko.observable('')
  };
  
  function clearSale(x) {
    x.agent.name('');
    x.reportCode('');
    x.create('');
  }

  clearSale(it.editedSaleData);

  it.saveNewItem = function () {
    var copy = ko.toJS(it.editedSaleData);
    
    $.ajax('/Handlers/ApiHandler.axd', {
      data: {
        entity: 'sale',
        action: 'add',
        object: ko.toJSON(copy)
      },
      type: 'GET',
      dataType: 'json',
      contentType: 'application/json; charset=utf-8',
      success: function (resp) {
        it.items.push(resp);
        clearSale(it.editedSaleData);
      }
    });
  };
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
        // This will be called once when the binding is first applied to an element,
        // and again whenever any observables/computeds that are accessed change
        // Update the DOM element based on the supplied values here.
      }
    };

    var model = $('.b-sales').data('model');
    ko.applyBindings(new SalesVm(model));
  }
});