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

            // TODO: Calculate Basket Total based on promotions.

            return total;
        }

        public decimal CalculatePromotionB()
        {
            // 1)  Get the total amount of items

            // 2) Given I have added a multiple of 3 lots of item ‘B’ to 
            // the basket Then a promotion of ‘3 for 40’ should be applied to every multiple of 3
            int multiple = 0;
            decimal calculatedUnitPrice = 0;
            decimal unitItemCost = 0;

            // Assume All costs for now are the same.
            if (this.Items != null && this.Items.Count > 0) 
            {
                unitItemCost = this.Items[0].UnitPrice;
            }

            for (int i = 1; i <= this.Items.Count; i++)
            {                               
                if (i % 3 == 0)
                {
                    multiple++;
                    calculatedUnitPrice = 40 * multiple;
                }
                else
                {
                    calculatedUnitPrice += unitItemCost;
                }
            }

          
            return calculatedUnitPrice;
        }
    }
}
