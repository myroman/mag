ko.bindingHandlers.datepicker = {
  init: function (element, valueAccessor, allBindings, viewModel, bindingContext) {
    if (ko.unwrap(valueAccessor())) {
      $(element).datepicker({
        //dateFormat: 'dd/mm/yy'
        dateFormat: 'yy-mm-dd'
      });
    }
  },
  update: function (element, valueAccessor, allBindings, viewModel, bindingContext) {
  }
};

Mag = { };
Mag.DateUtils = {
  getDateString: function(date) {
    return date.getFullYear() + '-' + this.addTrailZero(date.getMonth() + 1) + '-' + this.addTrailZero(date.getDate());
  },
  getDateStringNoInc: function (date) {
    return (date.getFullYear()) + '-' + this.addTrailZero(date.getMonth()) + '-' + this.addTrailZero(date.getDate());
  },
  addTrailZero: function (seg) {
    return ('0' + seg).slice(-2);
  }
};