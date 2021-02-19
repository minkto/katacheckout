using System;
using System.Collections.Generic;
using System.Text;

namespace CheckoutKata
{
    public class CalculatePromotionD : ICalculatePromotionD
    {
        public List<Item> Items { get; set; }

        public CalculatePromotionD()
        {

        }
        public CalculatePromotionD(List<Item> items)
        {
            Items = items;
        }


        /// <summary>
        /// This will calculate the Promotion of D.
        /// </summary>
        /// <returns>Returns a decimal featuring 2dp.</returns>
        public decimal CalculatePromotionDCost()
        {
            decimal calculatedUnitPrice = 0M;
            decimal unitItemCost = 0;
            decimal calculatedDiscountPrice = 0;

            // Assume All costs for now are the same.
            if (this.Items != null && this.Items.Count > 0)
            {
                unitItemCost = this.Items[0].UnitPrice;
            }

            for (int i = 1; i <= this.Items.Count; i++)
            {
                if (i % 2 == 0)
                {
                    calculatedUnitPrice += unitItemCost;
                    calculatedDiscountPrice = (25M / 100) * calculatedUnitPrice;
                    calculatedUnitPrice -= calculatedDiscountPrice;
                }
                else
                {
                    calculatedUnitPrice += unitItemCost;
                }
            }

            return Math.Round(calculatedUnitPrice, 2);

        }
    }
}
