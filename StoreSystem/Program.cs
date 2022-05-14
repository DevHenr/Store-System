using StoreSystem.Employees;
using System;
using System.IO;

namespace StoreSystem
{
    class Program
    {
        static int chosenProduct;
        static void Main(string[] args)
        {
            var store = new Store();

            var product1 = new Product("Plant pot", 10.50);
            var product2 = new Product("Coffee table", 329.45);
            var product3 = new Product("Water bottle", 1.50);
            var product4 = new Product("Sunglasses", 20.00);

            store.ProductList.Add(product1);
            store.ProductList.Add(product2);
            store.ProductList.Add(product3);
            store.ProductList.Add(product4);

            Console.WriteLine(ShowHeader());
            ShowProductList(store);

            string option;

            do
            {
                Console.Write(ShowMenu());

                switch (option = Console.ReadLine())
                {
                    case "1":
                        AddProductToInventory(store);
                        break;
                    case "2":
                        ShowProductList(store);
                        AddProductToShoppingList(store);
                        ShowShoppingList(store);

                        Console.WriteLine($"The total value now is: ${store.Bill()}");
                        break;
                    case "3":
                        RemoveProductFromShoppingList(store);
                        break;
                    case "4":
                        PrintShoppingList(store);
                        break;
                    case "5":
                        Console.Clear();
                        Console.WriteLine(ShowHeader());
                        ShowProductList(store);
                        break;
                    case "6":
                        break;
                    default:
                        Console.WriteLine("\nInvalid option.");
                        break;
                }
            } while (option != "6");

            static void ShowProductList(Store store)
            {
                for (int i = 0; i < store.ProductList.Count; i++)
                {
                    Console.WriteLine($"ID: {i} {store.ProductList[i]}");
                }
            }

            static string ShowHeader()
            {
                string header = "------ Welcome to the virtual store ------\r\n" +
                            "------------------------------------------\n\n" +
                            "Products currently available:\r";
                            
                return header;
            }

            static string ShowMenu()
            {
                string menu = "\nChoose an option from the following list:\n" +
                            "\t1 - Add a new product to the inventory\n" +
                            "\t2 - Add product to shopping list\n" +
                            "\t3 - Remove product from shopping list\n" +
                            "\t4 - Print shopping list\n" +
                            "\t5 - Clear screen\n" +
                            "\t6 - Quit\n" +
                            "Your option: ";
                return menu;
            }

            static void ShowShoppingList(Store store)
            {
                for (int i = 0; i < store.ShoppingList.Count; i++)
                {
                    Console.WriteLine($"Product - {store.ShoppingList[i]}");
                }
            }

            static void AddProductToInventory(Store store)
            {
                string ProductName;
                double ProductPrice;

                Console.Write("\nName of the product to be inserted: ");
                ProductName = Console.ReadLine();

                Console.Write("Price of the product to be inserted: ");
                string inputValue = Console.ReadLine();

                bool success = double.TryParse(inputValue, out ProductPrice);

                while (success != true)
                {
                    Console.WriteLine("Invalid typed value, please try again.");
                    Console.Write("Price of the product to be inserted: ");
                    inputValue = Console.ReadLine();
                    success = double.TryParse(inputValue, out ProductPrice);
                }

                Product newProduct = new Product(ProductName, ProductPrice);
                store.ProductList.Add(newProduct);

                Console.WriteLine($"\nNew product added: {newProduct}");
            }

            static void AddProductToShoppingList(Store store)
            {
                Console.WriteLine("\nWhat product would you like to add to your shopping list? Enter the ID.");
                VerifyInput(store);

                store.ShoppingList.Add(store.ProductList[chosenProduct]);
            }

            static void RemoveProductFromShoppingList(Store store)
            {
                if (store.ShoppingList.Count == 0)
                {
                    Console.WriteLine("\nYou don't have any products on your shopping list to be removed.");
                }
                else
                {
                    Console.WriteLine("\nWhat product would you like to remove from your shopping list? Enter the ID.");
                    VerifyInput(store);

                    Console.WriteLine("Want to perform the operation: Yes/No");
                    string decision = Console.ReadLine().ToLower();

                    if (decision == "yes")
                    {
                        store.ShoppingList.Remove(store.ProductList[chosenProduct]);
                        ShowShoppingList(store);

                        Console.WriteLine($"The total value now is: ${store.Bill()}");
                    }
                    else if (decision == "no")
                    {
                        Console.WriteLine("Operation canceled.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid option.");
                    }

                }
            }

            static void PrintShoppingList(Store store)
            {
                var path = "ShoppingList.txt";

                if (store.ShoppingList.Count == 0)
                {
                    Console.WriteLine("\nYou don't have a shopping list to be printed.");
                }
                else
                {
                    using (StreamWriter sw = File.CreateText(path))
                    {
                        sw.WriteLine("------ Shopping list ------\n");

                        for (int i = 0; i < store.ShoppingList.Count; i++)
                        {
                            sw.WriteLine("Product - " + store.ShoppingList[i]);
                        }
                        sw.WriteLine($"\nThe total value is: ${store.Bill()}");
                    }

                    Console.WriteLine("\nThe shopping list was printed in the application's debug folder.");
                }

            }

            static void VerifyInput(Store store)
            {
                string inputValue = Console.ReadLine();

                bool success = int.TryParse(inputValue, out chosenProduct);

                while (success != true || chosenProduct > store.ProductList.Count)
                {
                    Console.WriteLine("Invalid typed value, please try again.");
                    inputValue = Console.ReadLine();
                    success = int.TryParse(inputValue, out chosenProduct);
                }

            }

        }

    }
}
