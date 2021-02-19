using System;
using System.Collections.Generic;

namespace CheckoutKata
{
    class Program
    {
        static void Main(string[] args)
        {
            ProcessKataConsole();
        }

        public static void ProcessKataConsole()
        {
            ConstructKataHeader();
            Basket basket = new Basket();
            string userInput = string.Empty;

            while (userInput != "CHECKOUT")
            {
                userInput = Console.ReadLine().ToUpper();
                switch (userInput)
                {
                    case "A":
                        basket.Items.Add(new Item("A", 10));
                        Console.WriteLine("Item A has been added.");
                        break;
                    case "B":
                        basket.Items.Add(new Item("B", 15));
                        Console.WriteLine("Item B has been added.");
                        break;
                    case "C":
                        basket.Items.Add(new Item("C", 40));
                        Console.WriteLine("Item C has been added.");
                        break;
                    case "D":
                        basket.Items.Add(new Item("D", 55));
                        Console.WriteLine("Item D has been added.");
                        break;
                }

                if (userInput == "CLEAR")
                {
                    basket.Items = new List<Item>();
                    Console.WriteLine("Your Basket has been cleared.");
                }

                else if (userInput == "CHECKOUT")
                {
                    Checkout checkout = new Checkout(basket,new CalculatePromotionB(), new CalculatePromotionD());
                    OutputCheckoutCost(checkout);
                }
            }
        }

        private static void OutputCheckoutCost(Checkout checkout)
        {
            Console.WriteLine("--- Current Cost: " + checkout.TotalBasketCost + " ---");
        }

        private static void ConstructKataHeader()
        {
            Console.WriteLine("==== Welcome To Paul's Checkout! ====");
            Console.WriteLine("If you would like to shop for some items, we currently have the options below.");
            Console.WriteLine("Item SKU --------------------|----------Unit Price------------|---------Promotions------------------------|");
            Console.WriteLine("---------------A-------------|---------------10---------------|-------------------------------------------|");
            Console.WriteLine("---------------B-------------|---------------15---------------|--------------------3 For 40---------------|");
            Console.WriteLine("---------------C-------------|---------------40---------------|-------------------------------------------|");
            Console.WriteLine("---------------D-------------|---------------55---------------|-------25% Off for every two purchased-----|");

        }
    }
}
