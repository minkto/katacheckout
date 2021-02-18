using System;
using System.Collections.Generic;
using System.Text;

namespace CheckoutKata
{
    /// <summary>
    /// Creates an instance of an item avaialble.
    /// </summary>
    public class Item
    {
        #region Properties

        /// <summary>
        /// The Unique Identifier for the Item.
        /// </summary>
        public string SKU { get; set; }

        /// <summary>
        /// The amount of which the item costs.
        /// </summary>
        public decimal UnitPrice { get; set; }

        #endregion

        #region Constructors
        public Item() 
        { 
        
        }

        public Item(string sku,decimal unitPrice) 
        {
            this.SKU = sku;
            this.UnitPrice = unitPrice;
        }
        #endregion
    }
}
