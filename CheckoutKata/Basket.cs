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


        public decimal TotalItemsCost { get { return CalculateBasketTotal(); }  }



        public Basket()
        {
            Items = new List<Item>();
        }

        public Basket(List<Item> items)
        {
            Items = items;
        }

        private decimal CalculateBasketTotal() 
        {
            decimal total = 0;

            if(Items != null) 
            { 
                foreach(Item item in Items) 
                {
                    total += item.UnitPrice;
                }
            }

            return total;
        }
    }
}
