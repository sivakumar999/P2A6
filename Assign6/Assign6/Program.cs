using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Assign6
{
    internal class Program
    {
        private static SqlConnection con;
        static SqlCommand cmd;
        static SqlDataReader reader;
        static string conStr = "server=DESKTOP-KQQHHP5\\SQLEXPRESS; database=ProductInventoryDb; trusted_connection=true;";

        static void Main(string[] args)
        {
            con = new SqlConnection(conStr);
            con.Open();

            while (true)
            {
                Console.WriteLine("Select an operation:");
                Console.WriteLine("1. View Products");
                Console.WriteLine("2. Insert Product");
                Console.WriteLine("3. Update Product");
                Console.WriteLine("4. Delete Product");
                Console.WriteLine("5. Exit");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        ViewProducts();
                        break;
                    case 2:
                        InsertProduct();
                        break;
                    case 3:
                        UpdateProduct();
                        break;
                    case 4:
                        DeleteProduct();
                        break;
                    case 5:
                        con.Close();
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }

        static void ViewProducts()
        {
            cmd = new SqlCommand("SELECT * FROM Products", con);
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine("ProductId: " + reader["ProductId"]);
                Console.WriteLine("ProductName: " + reader["ProductName"]);
                Console.WriteLine("Price: " + reader["Price"]);
                Console.WriteLine("Quantity: " + reader["Quantity"]);
                Console.WriteLine("MfDate: " + reader["MfDate"]);
                Console.WriteLine("ExpDate: " + reader["ExpDate"]);
                Console.WriteLine("_______________________________________________________________\n");
            }

            reader.Close();
        }

        static void InsertProduct()
        {
            Console.Write("Enter ProductID: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Enter ProductName: ");
            string productName = Console.ReadLine();

            Console.Write("Enter Price: ");
            decimal price = decimal.Parse(Console.ReadLine());

            Console.Write("Enter Quantity: ");
            int quantity = int.Parse(Console.ReadLine());

            Console.Write("Enter MfDate: ");
            DateTime mfDate = DateTime.Parse(Console.ReadLine());

            Console.Write("Enter ExpDate: ");
            DateTime expDate = DateTime.Parse(Console.ReadLine());

            cmd = new SqlCommand("INSERT INTO Products (ProductId,ProductName, Price, Quantity, MfDate, ExpDate) VALUES (@ProductId,@ProductName, @Price, @Quantity, @MfDate, @ExpDate)", con);
            cmd.Parameters.AddWithValue("@ProductId", id);
            cmd.Parameters.AddWithValue("@ProductName", productName);
            cmd.Parameters.AddWithValue("@Price", price);
            cmd.Parameters.AddWithValue("@Quantity", quantity);
            cmd.Parameters.AddWithValue("@MfDate", mfDate);
            cmd.Parameters.AddWithValue("@ExpDate", expDate);

            int rowsAffected = cmd.ExecuteNonQuery();

            if (rowsAffected > 0)
            {
                Console.WriteLine("Product inserted successfully.");
            }
            else
            {
                Console.WriteLine("Insertion failed.");
            }
        }

        static void UpdateProduct()
        {
            Console.Write("Enter ProductId to update: ");
            int productId = int.Parse(Console.ReadLine());

            Console.Write("Enter new ProductName: ");
            string newProductName = Console.ReadLine();

            Console.Write("Enter new Price: ");
            decimal newPrice = decimal.Parse(Console.ReadLine());

            Console.Write("Enter new Quantity: ");
            int newQuantity = int.Parse(Console.ReadLine());

            Console.Write("Enter new MfDate: ");
            DateTime newMfDate = DateTime.Parse(Console.ReadLine());

            Console.Write("Enter new ExpDate: ");
            DateTime newExpDate = DateTime.Parse(Console.ReadLine());

            cmd = new SqlCommand("UPDATE Products SET ProductName = @NewProductName, Price = @NewPrice, Quantity = @NewQuantity, MfDate = @NewMfDate, ExpDate = @NewExpDate WHERE ProductId = @ProductId", con);
            cmd.Parameters.AddWithValue("@ProductId", productId);
            cmd.Parameters.AddWithValue("@NewProductName", newProductName);
            cmd.Parameters.AddWithValue("@NewPrice", newPrice);
            cmd.Parameters.AddWithValue("@NewQuantity", newQuantity);
            cmd.Parameters.AddWithValue("@NewMfDate", newMfDate);
            cmd.Parameters.AddWithValue("@NewExpDate", newExpDate);

            int rowsAffected = cmd.ExecuteNonQuery();

            if (rowsAffected > 0)
            {
                Console.WriteLine("Product updated successfully.");
            }
            else
            {
                Console.WriteLine("Update failed. Product not found.");
            }
        }

        static void DeleteProduct()
        {
            Console.Write("Enter ProductId to delete: ");
            int productId = int.Parse(Console.ReadLine());

            cmd = new SqlCommand("DELETE FROM Products WHERE ProductId = @ProductId", con);
            cmd.Parameters.AddWithValue("@ProductId", productId);

            int rowsAffected = cmd.ExecuteNonQuery();

            if (rowsAffected > 0)
            {
                Console.WriteLine("Product deleted successfully.");
            }
            else
            {
                Console.WriteLine("Deletion failed. Product not found.");
            }
        }
    }
}
