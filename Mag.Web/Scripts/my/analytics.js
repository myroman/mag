function AnalyticsVm(model) {
  console.log(model);
  var it = this;

  it.refresh = function() {
    console.log('clicked');
  };
  
  var filterData = function (plainData) {
    this.from = ko.observable();
    this.to = ko.observable();
    
    this.defaultFrom = null;
    this.defaultTo = null;
    
    this.update(plainData);
  };

  ko.utils.extend(filterData.prototype, {
    convertDate: function (serverDate) {
      console.log('Serverdate: ' + serverDate);
      var date = new Date(serverDate);
      var d2 = date.toUTCString();
      var dateString = Mag.DateUtils.getDateString(date);
      console.log('Datestring: ' + dateString); 
      return dateString;
    },
    update: function (data) {
      this.defaultFrom = data.defaultFrom;
      this.defaultTo = data.defaultTo;

      this.from(this.defaultFrom);
      this.to(this.defaultTo);
    }
  });

  it.filter = new filterData(model.filter);
}

$(function () {
  if ($('.b-anls').length > 0) {
    var model = $('.b-anls').data('model');
    ko.applyBindings(new AnalyticsVm(model));
  }
});