﻿using System;
using Nop.Core.Domain.Catalog;

namespace Nop.Core.Domain.Orders
{
    /// <summary>
    /// Represents a shopping cart item
    /// </summary>
    public partial class ShoppingCartItem : BaseEntity, IProductConfiguration
    {
        /// <summary>
        /// Gets or sets the store identifier
        /// </summary>
        public int StoreId { get; set; }

        /// <summary>
        /// Gets or sets the shopping cart type identifier
        /// </summary>
        public int ShoppingCartTypeId { get; set; }

        /// <summary>
        /// Gets or sets the customer identifier
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the product identifier
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets the product attributes in XML format
        /// </summary>
        public string AttributesXml { get; set; }

        /// <summary>
        /// Gets or sets the price enter by a customer
        /// </summary>
        public decimal CustomerEnteredPrice { get; set; }

        /// <summary>
        /// Gets or sets the quantity
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the rental product start date (null if it's not a rental product)
        /// </summary>
        public DateTime? RentalStartDateUtc { get; set; }

        /// <summary>
        /// Gets or sets the rental product end date (null if it's not a rental product)
        /// </summary>
        public DateTime? RentalEndDateUtc { get; set; }

        /// <summary>
        /// Gets or sets the date and time of instance creation
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// Gets or sets the date and time of instance update
        /// </summary>
        public DateTime UpdatedOnUtc { get; set; }

        /// <summary>
        /// Gets the log type
        /// </summary>
        public ShoppingCartType ShoppingCartType
        {
            get => (ShoppingCartType)ShoppingCartTypeId;
            set => ShoppingCartTypeId = (int)value;
        }

        /// <summary>
        /// Gets or sets the configurationdata of the configured product. This is defined in JSON
        /// PCFG
        /// </summary>
        public string Configuration { get; set; }

        /// <summary>
        /// Gets or sets the readable text of the configured product
        /// PCFG
        /// </summary>
        public string ConfigurationDescription { get; set; }

        /// <summary>
        /// Gets or sets the picture id of the configured product
        /// PCFG
        /// </summary>
        public int ConfigurationPictureId { get; set; }

        /// <summary>
        /// Gets or sets the price of the configured product
        /// PCFG
        /// </summary>
        public decimal ConfigurationPrice { get; set; }
    }
}
