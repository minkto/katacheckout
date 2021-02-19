using System;

namespace CheckoutKata
{
    /// <summary>
    /// The instance that will enable the calculation of the
    /// items added to be checked out.
    /// </summary>
    public class Checkout
    {
        private Basket basket;
        public decimal TotalBasketCost { get { return CalculateBasketTotal(); } }
        private ICalculatePromotionB calculatePromotionB;
        private ICalculatePromotionD calculatePromotionD;


        public Checkout(Basket basket) 
        {
            this.basket = basket;  
        }


        public Checkout(Basket basket, 
            ICalculatePromotionB calculatePromotionB,
            ICalculatePromotionD calculatePromotionD)
        {
            this.basket = basket;
            this.calculatePromotionB = calculatePromotionB;
            this.calculatePromotionD = calculatePromotionD;
        }
       


        private decimal CalculateBasketTotal()
        {
            decimal total = 0;
            decimal itemBTotalCost = 0;
            decimal itemDTotalCost = 0;

            if (basket.Items != null)
            {
                foreach (Item item in basket.Items)
                {
                    total += item.UnitPrice;
                }

                // Seperate the Items from B and D.
                // Calculate Cost of All Items seperately. TODO       
                if(calculatePromotionB != null) 
                {
                    itemBTotalCost = calculatePromotionB.CalculatePromotionBCost();
                }

                if(calculatePromotionD != null) 
                { 
                    itemDTotalCost = calculatePromotionD.CalculatePromotionDCost();
                }

            }
            // TODO: Calculate Basket Total based on promotions.
            return total;
        }


    }
}
