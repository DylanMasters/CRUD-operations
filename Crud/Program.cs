using System;
using MySql.Data.MySqlClient;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Crud
{
    class Program
    {
        static void Main(string[] args)
        {
#if DEBUG
            string jsonText = File.ReadAllText("appsettings.development.json");
#else
            string jsonText = File.ReadAllText("appsettings.release.json");
#endif
            var connString = JObject.Parse(jsonText)["ConnectionStrings"]["DefaultConnection"].ToString();
            var prod = new ProductRepository(connString);



            ProductRepository repo = new ProductRepository(connString);

            Console.WriteLine("please choose one of the following");
            Console.WriteLine("1) View a product");
            Console.WriteLine("2) update a product");
            Console.WriteLine("3) create a product");
            Console.WriteLine("4) delete a product");
            Console.WriteLine("5) exit");

            string response = Console.ReadLine();

            while (response != "5")
            {
                switch (response)
                {
                    case "1":
                        List<Product> products = repo.GetAllProducts();
                        
                        foreach (var product in products)
                        {
                            Console.WriteLine();
                        }
                        break;

                    case "2":
                        Console.WriteLine("what product would you like to update?");
                        int productID = int.Parse(Console.ReadLine());

                        Console.WriteLine("what would you like it's new name to be?");
                        string name = Console.ReadLine();

                        Console.WriteLine("what is the new product's category id?");
                        int categoryID = int.Parse(Console.ReadLine());

                        Console.WriteLine("what is the price of the new product?");
                        int price = int.Parse(Console.ReadLine());

                        repo.CreateProduct(new Product() { Name = name, Price = price, CategoryID = categoryID, });
                        break;

                    case "3":
                        //TODO implement create method
                        break;

                    case "4":
                        //TODO implement delete method
                        break;
                        
                        
                }
            }

        }
    }
}