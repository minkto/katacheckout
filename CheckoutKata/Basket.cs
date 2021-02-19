using System;
using System.Collections.Generic;
using System.Text;

namespace CheckoutKata
{
    /// <summary>
    /// Creates an instance of a Basket, to be used for
    /// the checkout.
    /// </summary>
    public class Basket
    {
        /// <summary>
        /// The Items that currently belong to the Basket.
        /// </summary>
        public List<Item> Items { get; set; }



        public Basket()
        {
            Items = new List<Item>();
        }

        /// <summary>
        /// Creates a Basket with Items included.
        /// </summary>
        /// <param name="items">Items</param>
        public Basket(List<Item> items)
        {
            Items = items;
        }
    }
}
