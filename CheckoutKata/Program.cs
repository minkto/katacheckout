using System;
using System.Collections.Generic;

namespace CheckoutKata
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("==== Welcome To Paul's Checkout! ====");
            Console.WriteLine("If you would like to shop for some items, we currently have the options below.");

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
                        OutputCurrentBasket(basket);
                        break;
                    case "B":
                        basket.Items.Add(new Item("B", 15));
                        Console.WriteLine("Item B has been added.");
                        OutputCurrentBasket(basket);
                        break;
                    case "C":
                        basket.Items.Add(new Item("C", 40));
                        Console.WriteLine("Item C has been added.");
                        OutputCurrentBasket(basket);
                        break;
                    case "D":
                        basket.Items.Add(new Item("D", 55));
                        Console.WriteLine("Item D has been added.");
                        OutputCurrentBasket(basket);
                        break;
                }

                if(userInput == "CLEAR") 
                {
                    basket.Items = new List<Item>();
                    Console.WriteLine("Your Basket has been cleared.");
                }

                else if(userInput == "COST") 
                {
                    OutputCurrentBasket(basket);
                }
            }
        }

        private static void OutputCurrentBasket(Basket basket)
        {
            Console.WriteLine("--- Current Cost: " + basket.TotalItemsCost + " ---");
        }
    }
}
