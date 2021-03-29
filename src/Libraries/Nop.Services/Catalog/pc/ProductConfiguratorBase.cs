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

        public (object model, string description, decimal price, bool isValid) Calculate(T model)
        {
            bool isValid;
            (model, isValid) = Validate(model);
            var description = CreateDescription(model);

            decimal price;
            (model, price) = CalculatePrice(model);

            return (model, description, price, isValid);
        }

        public (object model, string description, decimal price, bool isValid) Calculate(string json)
        {
            try
            {
                var model = (T)JsonConvert.DeserializeObject(json, typeof(T));
                return Calculate(model);
            }
            catch
            {
                return (null, null, 0, false);
            }
        }

        protected abstract (T, bool) Validate(T model);

        protected abstract string CreateDescription(T model);

        public Type GetModelType()
        {
            return _modelType;
        }

        public T GetDefault()
        {
            return CreateDefaultModel();
        }

        protected abstract T CreateDefaultModel();

        public (string model, string description, decimal price, bool isValid) CalculateToJson(string json)
        {
            object model;
            decimal price;
            string description;
            bool isValid;
            (model, description, price, isValid) = Calculate(json);

            return (JsonConvert.SerializeObject(model), description, price, isValid);
        }

        public (string model, string description, decimal price, bool isValid) CalculateToJson(T model)
        {
            object modelOut;
            decimal price;
            string description;
            bool isValid;
            (modelOut, description, price, isValid) = Calculate(model);

            return (JsonConvert.SerializeObject(modelOut), description, price, isValid);
        }

        protected abstract (T model, decimal price) CalculatePrice(T model);
    }
}