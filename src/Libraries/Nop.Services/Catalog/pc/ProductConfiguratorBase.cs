using System;
using Newtonsoft.Json;

namespace Nop.Services.Catalog
{
    /// <summary>
    /// Product Configurator Base
    /// </summary>
    /// <typeparam name="T">The model of a product configurator</typeparam>
    public abstract class ProductConfiguratorBase<T> : IProductConfiguratorProvider
        //where T : ProductConfiguratorModel
    {
        private readonly string _viewName;
        private readonly Type _modelType;

        protected ProductConfiguratorBase(string viewName)
        {
            _viewName = viewName;
            _modelType = typeof(T);
        }

        public string GetViewName()
        {
            return _viewName;
        }

        public object GetDefaultModel()
        {
            return CreateDefaultModel();
        }

        public (object model, decimal price) Calculate(string json)
        {
            var model = (T)JsonConvert.DeserializeObject(json, typeof(T));

            return Calculate(model);
        }

        public Type GetModelType()
        {
            return _modelType;
        }

        protected abstract T CreateDefaultModel();

        public (string model, decimal price) CalculateToJson(string json)
        {
            object model;
            decimal price;
            (model, price) = Calculate(json);

            return (JsonConvert.SerializeObject(model), price);
        }

        protected abstract (T model, decimal price) Calculate(T model);
    }
}