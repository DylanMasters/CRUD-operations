using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace Crud
{
    class ProductRepository
    {
        private string connectionString;

        public ProductRepository(string _connectionString)
        {
            connectionString = _connectionString;
        }

        public void CreateProduct(Product prod)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);

            using (conn)
            {
                conn.Open();

                var cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO products (Name, Price, CategoryID) Values (@n, @p, @cID);";
                cmd.Parameters.AddWithValue("n", prod.Name);
                cmd.Parameters.AddWithValue("p", prod.Price);
                cmd.Parameters.AddWithValue("cID", prod.CategoryID);
                cmd.ExecuteNonQuery();
            }
        }

        public List<Product> GetAllProducts()
        {
            MySqlConnection conn = new MySqlConnection(connectionString);

            List<Product> products = new List<Product>();

            using (conn)
            {
                conn.Open();

                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT ProductID, Name, Price, CategoryID FROM products;";

                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    Product product = new Product()
                    {
                        ProductID = (int)dataReader["ProductID"],
                        Name = dataReader["Name"].ToString(),
                        Price = (decimal)dataReader["Price"],
                        CategoryID = (int)dataReader["CategoryID"]
                    };
                    products.Add(product);
                    Console.WriteLine($"{product.ProductID}.....{product.Name}.....{product.Price}.....{product.CategoryID}");

                }
                return products;
            }
        }

        public void UpdateProduct(Product prod)
        {
            var conn = new MySqlConnection(connectionString);

            using (conn)
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE products SET Name = @n, Price = @p, " +
                                  "CategoryID = @cID WHERE ProductID = @pID;";
                cmd.Parameters.AddWithValue("n", prod.Name);
                cmd.Parameters.AddWithValue("p", prod.Price);
                cmd.Parameters.AddWithValue("cID", prod.CategoryID);
                cmd.Parameters.AddWithValue("pID", prod.ProductID);
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteProduct(int id)
        {
            var conn = new MySqlConnection(connectionString);

            using (conn)
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM products WHERE ProductID = @id;";
                cmd.Parameters.AddWithValue("id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
