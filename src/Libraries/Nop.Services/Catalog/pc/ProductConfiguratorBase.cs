﻿using System;
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

        public Type GetModelType()
        {
            return _modelType;
        }

        protected abstract T CreateDefaultModel();

        public string Calculate(string json)
        {
            var model = (T)JsonConvert.DeserializeObject(json, typeof(T));

            model = Calculate(model);

            return JsonConvert.SerializeObject(model);
        }

        protected abstract T Calculate(T model);
    }
}