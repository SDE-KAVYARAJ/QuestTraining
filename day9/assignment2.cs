/*Inventory Management System for a Store
You are asked to build a simple inventory management system for a store to track product stock and prices.
Requirements:
Use a dictionary to store product details:
Key: Product ID (unique for each product).
Value: A dictionary containing:
"Name" (string): The product name.
"Price" (decimal): The price of the product.
"Stock" (int): The current stock of the product.
Implement the following functions:
AddProduct: Add a new product to the inventory.
UpdateStock: Update the stock quantity for a product.
GetProductDetails: Retrieve product information based on the product ID.
GetLowStockProducts: Return a list of products that have stock below a certain threshold.
has context menu*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inventorys
{
    internal class Program
    {
        static Dictionary<string, Dictionary<string, object>>inventory = new Dictionary<string, Dictionary<string, object>>();

        static void AddProduct()
        {
            Console.WriteLine("Enter Product ID:");
            var productId = Console.ReadLine();

            Console.WriteLine("Enter Product Name:");
            var productName = Console.ReadLine();

            Console.WriteLine("Enter Product Price:");
            var productPrice = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Enter Product Stock:");
            var productStock = int.Parse(Console.ReadLine());

            var productDetails = new Dictionary<string, object>
            {
                { "Name", productName },
                { "Price", productPrice },
                { "Stock", productStock }
            };

            inventory.Add(productId, productDetails);
            Console.WriteLine($"Product '{productName}' added successfully with ID: {productId}");
        }


        static void UpdateStock()
        {
            Console.WriteLine("Enter Product ID to update stock:");
            var productId = Console.ReadLine();

            if (inventory.ContainsKey(productId))
            {
                Console.WriteLine("Enter new stock quantity:");
                var newStock = int.Parse(Console.ReadLine());

                inventory[productId]["Stock"] = newStock;
                Console.WriteLine($"Stock for product ID '{productId}' updated to {newStock}.");
            }
            else
            {
                Console.WriteLine("Product ID not found.");
            }
        }

        static void GetProductDetails()
        {
            Console.WriteLine("Enter Product ID to retrieve details:");
            var productId = Console.ReadLine();

            if (inventory.ContainsKey(productId))
            {
                var product = inventory[productId];
                Console.WriteLine($"Product ID: {productId}");
                Console.WriteLine($"Name: {product["Name"]}");
                Console.WriteLine($"Price: {product["Price"]}");
                Console.WriteLine($"Stock: {product["Stock"]}");
            }
            else
            {
                Console.WriteLine("Product ID not found.");
            }
        }


        static void GetLowStockProducts()
        {
            Console.WriteLine("Enter stock threshold:");
            var threshold = int.Parse(Console.ReadLine());

            List<string> lowStockProducts = new List<string>();

            foreach (var product in inventory)
            {
                
                if ((int)product.Value["Stock"] < threshold)
                {
                    lowStockProducts.Add(product.Key); 
                }
            }

            if (lowStockProducts.Count > 0)
            {
                Console.WriteLine("Products with stock below threshold:");
                foreach (var id in lowStockProducts)
                {
                    Console.WriteLine($"Product ID: {id}, Name: {inventory[id]["Name"]}, Stock: {inventory[id]["Stock"]}");
                }
            }
            else
            {
                Console.WriteLine("No products below the specified stock threshold.");
            }

        }
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\nChoose an option:");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. Update Stock");
                Console.WriteLine("3. Get Product Details");
                Console.WriteLine("4. Get Low Stock Products");
                Console.WriteLine("5. Exit");

                var option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        AddProduct();
                        break;
                    case "2":
                        UpdateStock();
                        break;
                    case "3":
                        GetProductDetails();
                        break;
                    case "4":
                        GetLowStockProducts();
                        break;
                    case "5":
                        return; // Exit the program
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }

        }
    }
}
