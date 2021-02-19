using System;
using System.Collections.Generic;
using System.Text;

namespace CheckoutKata
{
    /// <summary>
    /// Interface to  the calculation of promotion D.
    /// </summary>
    public interface ICalculatePromotionD
    {
        public List<Item> Items { get; set; }
        public decimal CalculatePromotionDCost();
    }
}
