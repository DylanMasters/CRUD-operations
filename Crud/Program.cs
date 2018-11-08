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

<<<<<<< HEAD
=======


>>>>>>> 90801614f564dff0884789f4ea19f9fd00bca894
            ProductRepository repo = new ProductRepository(connString);

            Console.WriteLine("please choose one of the following");
            Console.WriteLine("1) View a product");
            Console.WriteLine("2) update a product");
            Console.WriteLine("3) create a product");
            Console.WriteLine("4) delete a product");
            Console.WriteLine("5) exit");

            string response = Console.ReadLine();
            Console.Clear();
            bool exitClause = true;
            while (exitClause == true)
            {
                switch (response)
                {
                    case "1":
                        var product = new ProductRepository(connString);
                        List<Product> products = product.GetAllProducts();
                        Console.ReadLine();
                        exitClause = false;
                        break;

                    case "2":
                        Console.WriteLine("what is the product ID you would like to use for this item?");
                        int productID = int.Parse(Console.ReadLine());

                        Console.WriteLine("what would you like it's name to be?");
                        string name = Console.ReadLine();

                        Console.WriteLine("what is the new product's category id?");
                        int categoryID = int.Parse(Console.ReadLine());

                        Console.WriteLine("what is the price of the new product?");
                        int price = int.Parse(Console.ReadLine());

                        repo.UpdateProduct(new Product() { ProductID = productID, Name = name, Price = price, CategoryID = categoryID, });
                        exitClause = false;
                        break;

                    case "3":
                        //TODO implement create method
                        Console.WriteLine("what is the name of the product you would like to add?");
                        string name1 = Console.ReadLine();
                        Console.WriteLine("what is the price of your new product?");
                        decimal price1 = int.Parse(Console.ReadLine());
                        Console.WriteLine("what will your category ID be?");
                        int catID1 = int.Parse(Console.ReadLine());
                        repo.CreateProduct(new Product() { Name = name1, Price = price1, CategoryID = catID1, });
                        exitClause = false;
                        break;


                    case "4":
                        //TODO implement delete method
                        Console.WriteLine("what is the product ID of the item you wish to delete?");
                        int pID = int.Parse(Console.ReadLine());
                        repo.DeleteProduct(pID);
                        exitClause = false;
                        break;

                    case "5":
                        break;
                }
            }

        }
    }
}