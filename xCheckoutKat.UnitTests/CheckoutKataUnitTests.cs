using CheckoutKata;
using System;
using Xunit;

namespace xCheckoutKat.UnitTests
{
    public class CheckoutKataUnitTests
    {
        [Fact]
        public void Basket_Add_Item()
        {
            // Arrange
            Basket basket = new Basket();

            // Act 
            basket.Items.Add(new Item("A", 10));
            basket.Items.Add(new Item("B", 10));

            // Assert
            Assert.Equal(2, basket.Items.Count);
        }

        [Fact]
        public void Checkout_Basket_Calculate_Individual_Items_Total()
        {
            // Arrange
            Basket basket = new Basket();

            // Act 
            basket.Items.Add(new Item("A", 10));
            basket.Items.Add(new Item("B", 15));
            basket.Items.Add(new Item("D", 40));
            basket.Items.Add(new Item("D", 55));

            Checkout checkout = new Checkout(basket);

            // Assert
            Assert.Equal(120, checkout.TotalBasketCost);
        }

        #region Promotion B Tests
        [Fact]
        public void Checkout_Basket_Calculate_Individual_Promotion_B_Items_Only_Multiple_3_Item_Count()
        {
            // Arrange - Multples of 3 starting with 3.
            ICalculatePromotionB calculatePromotionB3Items = new CalculatePromotionB(GenerateSpecifiedItemsBasket(3, "B", 15).Items);
            ICalculatePromotionB calculatePromotionB6Items = new CalculatePromotionB(GenerateSpecifiedItemsBasket(6, "B", 15).Items);
            ICalculatePromotionB calculatePromotionB9Items = new CalculatePromotionB(GenerateSpecifiedItemsBasket(9, "B", 15).Items);
            ICalculatePromotionB calculatePromotionB12Items = new CalculatePromotionB(GenerateSpecifiedItemsBasket(12, "B", 15).Items);


            // Assert
            Assert.Equal(40, calculatePromotionB3Items.CalculatePromotionBCost());
            Assert.Equal(80, calculatePromotionB6Items.CalculatePromotionBCost());
            Assert.Equal(120, calculatePromotionB9Items.CalculatePromotionBCost());
            Assert.Equal(160, calculatePromotionB12Items.CalculatePromotionBCost());
        }

        [Fact]
        public void Checkout_Basket_Calculate_Individual_Promotion_B_Items_No_Promotion_Item_Count()
        {
            // Arrange 
            ICalculatePromotionB calculatePromotionB2Items = new CalculatePromotionB(GenerateSpecifiedItemsBasket(2, "B", 15).Items);


            // Assert
            Assert.Equal(30, calculatePromotionB2Items.CalculatePromotionBCost());
        }

        [Fact]
        public void Checkout_Basket_Calculate_Individual_Promotion_B_Mixed_Amount()
        {
            // Arrange 
            ICalculatePromotionB calculatePromotionB5Items = new CalculatePromotionB(GenerateSpecifiedItemsBasket(5, "B", 15).Items);
            ICalculatePromotionB calculatePromotionB8Items = new CalculatePromotionB(GenerateSpecifiedItemsBasket(8, "B", 15).Items);
            ICalculatePromotionB calculatePromotionB11Items = new CalculatePromotionB(GenerateSpecifiedItemsBasket(11, "B", 15).Items);


            // Assert
            Assert.Equal(70, calculatePromotionB5Items.CalculatePromotionBCost());
            Assert.Equal(110, calculatePromotionB8Items.CalculatePromotionBCost());
            Assert.Equal(150, calculatePromotionB11Items.CalculatePromotionBCost());

        }

        #endregion

        #region Promotion D Tests
        [Fact]
        public void Checkout_Basket_Calculate_Individual_Promotion_D_Items_Only_Multiple_2_Item_Count()
        {
            // Arrange - Multples of 2 starting with 2.

            ICalculatePromotionD calculatePromotionD2Items = new CalculatePromotionD(GenerateSpecifiedItemsBasket(2, "D", 55).Items);
            ICalculatePromotionD calculatePromotionD4Items = new CalculatePromotionD(GenerateSpecifiedItemsBasket(4, "D", 55).Items);
            ICalculatePromotionD calculatePromotionD6Items = new CalculatePromotionD(GenerateSpecifiedItemsBasket(6, "D", 55).Items);
            ICalculatePromotionD calculatePromotionD8Items = new CalculatePromotionD(GenerateSpecifiedItemsBasket(8, "D", 55).Items);

            // Assert
            Assert.Equal(Math.Round(82.50M, 2), calculatePromotionD2Items.CalculatePromotionDCost());
            Assert.Equal(Math.Round(144.38M, 2), calculatePromotionD4Items.CalculatePromotionDCost());
            Assert.Equal(Math.Round(190.78M, 2), calculatePromotionD6Items.CalculatePromotionDCost());
            Assert.Equal(Math.Round(225.59M, 2), calculatePromotionD8Items.CalculatePromotionDCost());
        }

        [Fact]
        public void Checkout_Basket_Calculate_Individual_Promotion_D_Items_Only_No_Promotion()
        {
            // Arrange
            ICalculatePromotionD calculatePromotionD2Items = new CalculatePromotionD(GenerateSpecifiedItemsBasket(1, "D", 55).Items);

            // Assert
            Assert.Equal(55, calculatePromotionD2Items.CalculatePromotionDCost());
        }

        [Fact]
        public void Checkout_Basket_Calculate_Individual_Promotion_D_Mixed_Amount()
        {
            // Arrange 
            ICalculatePromotionD calculatePromotionD3Items = new CalculatePromotionD(GenerateSpecifiedItemsBasket(3, "D", 55).Items);
            ICalculatePromotionD calculatePromotionD5Items = new CalculatePromotionD(GenerateSpecifiedItemsBasket(5, "D", 55).Items);
            ICalculatePromotionD calculatePromotionD7Items = new CalculatePromotionD(GenerateSpecifiedItemsBasket(7, "D", 55).Items);
            ICalculatePromotionD calculatePromotionD8Items = new CalculatePromotionD(GenerateSpecifiedItemsBasket(8, "D", 55).Items);

            // Assert
            Assert.Equal(Math.Round(137.50M, 2), calculatePromotionD3Items.CalculatePromotionDCost());
            Assert.Equal(Math.Round(199.38M, 2), calculatePromotionD5Items.CalculatePromotionDCost());
            Assert.Equal(Math.Round(245.78M, 2), calculatePromotionD7Items.CalculatePromotionDCost());
            Assert.Equal(Math.Round(225.59M, 2), calculatePromotionD8Items.CalculatePromotionDCost());

        }
        #endregion

        #region Checkout Calculation
        public void Checkout_Basket_Calculate_All_Item_Types_With_B_Promotion()
        { 
            // TODO:
        }

        public void Checkout_Basket_Calculate_All_Item_Types_With_D_Promotion()
        {
            // TODO:
        }

        public void Checkout_Basket_Calculate_All_Item_Types_With_B_D_Promotion()
        {
            // TODO:
        }

        #endregion

        public Basket GenerateSpecifiedItemsBasket(int amountOfItems,string itemSKU,decimal unitCost) 
        {
            Basket basket = new Basket();

            for (int i = 0; i < amountOfItems; i++)
            {
                basket.Items.Add(new Item(itemSKU, unitCost));
            }

            return basket;
        }
    }
}
