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

        public (object model, string description, decimal price, bool isValid) Calculate(string json)
        {
            T model = default;
            try
            {
                model = (T)JsonConvert.DeserializeObject(json, typeof(T));
            }
            catch (Exception e)
            {
            }

            bool isValid;
               (model, isValid) = Validate(model);
            var description = CreateDescription(model);

            decimal price;
            (model, price) = CalculatePrice(model);

            return (model, description, price, isValid);
        }

        protected abstract (T, bool) Validate(T model);

        protected abstract string CreateDescription(T model);

        public Type GetModelType()
        {
            return _modelType;
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

        protected abstract (T model, decimal price) CalculatePrice(T model);
    }
}