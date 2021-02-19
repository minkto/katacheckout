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
        public void Basket_Calculate_Individual_Items_Total()
        {
            // Arrange
            Basket basket = new Basket();

            // Act 
            basket.Items.Add(new Item("A", 10));
            basket.Items.Add(new Item("B", 15));
            basket.Items.Add(new Item("D", 40));
            basket.Items.Add(new Item("D", 55));

            // Assert
            Assert.Equal(120, basket.TotalItemsCost);
        }

        #region Promotion B Tests
        [Fact]
        public void Basket_Calculate_Individual_Promotion_B_Items_Only_Multiple_3_Item_Count()
        {
            // Arrange - Multples of 3 starting with 3.
            Basket basketWith3BItems = GenerateSpecifiedItemsBasket(3,"B",15);
            Basket basketWith6BItems = GenerateSpecifiedItemsBasket(6, "B", 15);
            Basket basketWith9BItems = GenerateSpecifiedItemsBasket(9, "B", 15);
            Basket basketWith12BItems = GenerateSpecifiedItemsBasket(12, "B", 15);

            // Assert
            Assert.Equal(40, basketWith3BItems.CalculatePromotionB());
            Assert.Equal(80, basketWith6BItems.CalculatePromotionB());
            Assert.Equal(120, basketWith9BItems.CalculatePromotionB());
            Assert.Equal(160, basketWith12BItems.CalculatePromotionB());
        }

        [Fact]
        public void Basket_Calculate_Individual_Promotion_B_Items_No_Promotion_Item_Count()
        {
            // Arrange 
            Basket basket = GenerateSpecifiedItemsBasket(2, "B", 15);            

            // Assert
            Assert.Equal(30, basket.CalculatePromotionB());
        }

        [Fact]
        public void Basket_Calculate_Individual_Promotion_B_Mixed_Amount()
        {
            // Arrange 
            Basket basketWith5BItems = GenerateSpecifiedItemsBasket(5, "B", 15);
            Basket basketWith8BItems = GenerateSpecifiedItemsBasket(8, "B", 15);
            Basket basketWith11BItems = GenerateSpecifiedItemsBasket(11, "B", 15);

            // Assert
            Assert.Equal(70, basketWith5BItems.CalculatePromotionB());
            Assert.Equal(110, basketWith8BItems.CalculatePromotionB());
            Assert.Equal(150, basketWith11BItems.CalculatePromotionB());

        }

        #endregion

        #region Promotion D Tests
        [Fact]
        public void Basket_Calculate_Individual_Promotion_D_Items_Only_Multiple_2_Item_Count()
        {
            // Arrange - Multples of 2 starting with 2.
            Basket basketWith2DItems = GenerateSpecifiedItemsBasket(2, "D",55);
            Basket basketWith4DItems = GenerateSpecifiedItemsBasket(4, "D",55);
            Basket basketWith6DItems = GenerateSpecifiedItemsBasket(6, "D", 55);
            Basket basketWith8DItems = GenerateSpecifiedItemsBasket(8, "D", 55);

            // Assert
            Assert.Equal(Math.Round(82.50M, 2), basketWith2DItems.CalculatePromotionD());
            Assert.Equal(Math.Round(144.38M, 2), basketWith4DItems.CalculatePromotionD());
            Assert.Equal(Math.Round(190.78M, 2), basketWith6DItems.CalculatePromotionD());
            Assert.Equal(Math.Round(225.59M, 2), basketWith8DItems.CalculatePromotionD());
        }

        [Fact]
        public void Basket_Calculate_Individual_Promotion_D_Items_Only_No_Promotion()
        {
            Basket basketWith2DItems = GenerateSpecifiedItemsBasket(1, "D", 55);

            // Assert
            Assert.Equal(55, basketWith2DItems.CalculatePromotionD());
        }

        [Fact]
        public void Basket_Calculate_Individual_Promotion_D_Mixed_Amount()
        {
            // Arrange 
            Basket basketWith2DItems = GenerateSpecifiedItemsBasket(3, "D", 55);
            Basket basketWith4DItems = GenerateSpecifiedItemsBasket(5, "D", 55);
            Basket basketWith6DItems = GenerateSpecifiedItemsBasket(7, "D", 55);
            Basket basketWith8DItems = GenerateSpecifiedItemsBasket(8, "D", 55);

            // Assert
            Assert.Equal(Math.Round(137.50M, 2), basketWith2DItems.CalculatePromotionD());
            Assert.Equal(Math.Round(199.38M, 2), basketWith4DItems.CalculatePromotionD());
            Assert.Equal(Math.Round(245.78M, 2), basketWith6DItems.CalculatePromotionD());
            Assert.Equal(Math.Round(225.59M, 2), basketWith8DItems.CalculatePromotionD());

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
