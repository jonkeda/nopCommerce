﻿namespace Nop.Web.Prototype.Models
{
    public class PublicConfiguratorField<T>
    {
        public T Value { get; set; }
        //public T Default { get; set; }
        public bool IsVisible { get; set; } = true;
        public string Error { get; set; }

        public override string ToString()
        {
            return Value?.ToString();
        }
    }
    public class PublicConfiguratorModel
    {
        public PublicConfiguratorField<int> Price { get; set; } = new();

    }
}