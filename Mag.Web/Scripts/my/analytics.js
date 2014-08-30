function AnalyticsVm(model) {
  var it = this;

  it.refresh = function () {
    var plainFilterObj = ko.toJS(it.filter);
    
    $.ajax('/ApiHandler.axd', {
      data: {
        entity: 'anlsMag',
        action: 'list',
        object: ko.toJSON(plainFilterObj)
      },
      type: 'GET',
      dataType: 'json',
      beforeSend: function () {
        $('.loader').show();
      },
      success: function (data) {
        it.reportItems.removeAll();
        $.each(data, function() {
          it.reportItems.push(this);
        });
      },
      complete: function () {
        $('.loader').hide();
      }
    });
  };
  it.reportItems = ko.observableArray();
  it.hasItems = ko.computed(function() {
    return it.reportItems().length > 0;
  }, this);
  
  var filterData = function (plainData) {
    this.from = ko.observable();
    this.to = ko.observable();
    
    this.defaultFrom = null;
    this.defaultTo = null;
    
    this.update(plainData);
  };

  ko.utils.extend(filterData.prototype, {
    update: function (data) {
      this.defaultFrom = data.defaultFrom;
      this.defaultTo = data.defaultTo;
      this.quarters = data.quarters;
      
      this.from(this.defaultFrom);
      this.to(this.defaultTo);
    }
  });

  it.filter = new filterData(model.filter);

  function setDateIntervalAndRefresh(optionIndex) {
    var range = it.filter.quarters[optionIndex];
    it.filter.from(range.from);
    it.filter.to(range.to);

    it.refresh();
  }
  it.setQuart1 = function () {
    setDateIntervalAndRefresh(0);
  };
  it.setQuart2 = function() {
    setDateIntervalAndRefresh(1);
  };
  it.setQuart3 = function () {
    setDateIntervalAndRefresh(2);
  };
  it.setQuart4 = function () {
    setDateIntervalAndRefresh(3);
  };
  it.setYear = function() {
    setDateIntervalAndRefresh(4);
  };

  // calling
  it.refresh();
}

$(function () {
  if ($('.b-anls').length > 0) {
    var model = $('.b-anls').data('model');
    ko.applyBindings(new AnalyticsVm(model));
  }
});