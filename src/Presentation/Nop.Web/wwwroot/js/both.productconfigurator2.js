var productConfigurator = {
  Enabled: true,
  Fields: [],
  CalculateUrl: '',
  Initial: false,

  init(enabled, fields, calculateUrl, initial) {
    this.Enabled = enabled;
    this.Fields = fields;
    this.CalculateUrl = calculateUrl;
    this.Initial = initial;

    if (enabled) {
      $(document).ready(function() {
        if (window.opener) {
          if (productConfigurator.Initial) {
            var configuration = $('#Configuration', window.opener.document).val();
            productConfigurator.SetCfg(JSON.parse(configuration));
          }
          productConfigurator.Calculate();
        }
        var i;
        for (i = 0; i < productConfigurator.Fields.length; i++) {
          var field = productConfigurator.Fields[i];
          $("#" + field + '_Value').change(function() {
            productConfigurator.Calculate();
          });
        }
      });
    }
  },

  GetValue: function (id) {
    var value = {}
    value.Value = $('#' + id + '_Value').val();
    return value;
  },

  SetValue: function (id, data) {
    if (data) {
      valField('#' + id + '_Value', null, data.Value);
      //var el = $('#' + id + '_Value');
      //if (el) {
      //el.valField(data.Value);
      //if (data.isVisible) {
      //    //el.show();
      //    el.showField();
      //} else {
      //    el.hide();
      //}
      // todo error messages
      //}
    }
  },

  GetCfg: function () {
    var cfg = {}
    var i, field;
    for (i = 0; i < this.Fields.length; i++) {
      field = this.Fields[i];
      cfg[field] = this.GetValue(field);
    }
    return cfg;
  },

  SetCfg: function (cfg) {
    var i, field;
    for (i = 0; i < this.Fields.length; i++) {
      field = this.Fields[i];
      this.SetValue(field, cfg[field]);
    }
  },

  SetPrice: function (data) {
    $('#ProductConfigurator_Price').text(data.Price);
    $('#ProductConfigurator_Tax').text(data.Tax);
    $('#ProductConfigurator_SubTotal').text(data.SubTotal);
  },

  Calculate: function (cfg) {
    if (!cfg) {
      cfg = JSON.stringify(this.GetCfg());
    }
    var model = {};
    model.ConfiguratorId = $('#ConfiguratorId').val();
    model.Json = cfg;
    addAntiForgeryToken(model);
    $.ajax({
      type: 'POST',
      url: this.CalculateUrl,
      dataType: 'json',
      data: model,
      success: function (data) {
        productConfigurator.SetPrice(data);
        productConfigurator.SetCfg(JSON.parse(data.Json));
      },
      error: function (ex) {
        //window.alert(ex);
      }
    });
  },

  Cancel: function () {
    window.close();
  },

  Ok: function () {
    $("#Configuration", window.opener.document).val(JSON.stringify(this.GetCfg()));
    $("#ConfiguratorId", window.opener.document).val($('#ConfiguratorId').val());
    window.close();
  }
}

