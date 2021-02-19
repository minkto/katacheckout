using System;
using System.Collections.Generic;
using System.Text;

namespace CheckoutKata
{
    /// <summary>
    /// Interface to implemment the calculation of promotion B.
    /// </summary>
    public interface ICalculatePromotionB
    {
        public List<Item> Items{ get; set; }
        public decimal CalculatePromotionBCost();
    }
}
