var ProductConfiguratorEnabled = true;
var Configurationfields = [];
var ProductConfiguratorCalculateUrl;
var ProductConfiguratorModelName = '';
var ProductConfiguratorNameCamel = true;

var ConfigurationGetValue = function (id) {
  var value = {}
  value.Value = $('#' + id + '_Value').val();
  return value;
}
var ConfigurationSetValue = function (id, data) {
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
}
var ConfigurationGetCfg = function () {
  var cfg = {}
  var i, field, name;
  for (i = 0; i < Configurationfields.length; i++) {
    field = Configurationfields[i];
    cfg[field] = ConfigurationGetValue(field);
  }
  return cfg;
}
var ConfigurationSetCfg = function (data) {
  var i, field, name;
  for (i = 0; i < Configurationfields.length; i++) {
    field = Configurationfields[i];
    ConfigurationSetValue(field, data[field]);
  }
}
var ConfigurationSetPrice = function (data) {
  $('#ProductConfigurator_Price').text(data.Price);
  $('#ProductConfigurator_Tax').text(data.Tax);
  $('#ProductConfigurator_PriceIncludingTax').text(data.Price);
}
var ConfigurationCalculate = function (cfg) {
  if (!cfg) {
    cfg = JSON.stringify(ConfigurationGetCfg());
  }
  var model = {};
  model.ConfiguratorId = $('#ConfiguratorId').val();
  model.Json = cfg;
  addAntiForgeryToken(model);
  $.ajax({
    type: 'POST',
    url: ProductConfiguratorCalculateUrl,
    dataType: 'json',
    data: model,
    success: function (data) {
      ConfigurationSetPrice(data);
      ConfigurationSetCfg(JSON.parse(data.Json));
    },
    error: function (ex) {
      //window.alert(ex);
    }
  });
}
var ConfigurationCancel = function () {
  window.close();
}
var ConfigurationOk = function () {
  $("#Configuration", window.opener.document).val(JSON.stringify(ConfigurationGetCfg()));
  $("#ConfiguratorId", window.opener.document).val($('#ConfiguratorId').val());
  window.close();
}
