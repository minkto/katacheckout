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
            basket.Items.Add(new Item("C", 40));
            basket.Items.Add(new Item("D", 55));

            // Assert
            Assert.Equal(120, basket.TotalItemsCost);
        }

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
