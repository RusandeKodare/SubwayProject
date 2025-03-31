using subway_project.Server.Data;
using subway_project.Server.Models;

namespace subway_project.Server
{
    public class DbSeeder
    {
        public static void Seed(AppDbContext context)
        {
            if (!context.Categories.Any())
            {
                context.Categories.AddRange(
                    new Category { Name = "Bread" },
                    new Category { Name = "Toppings" },
                    new Category { Name = "Vegetables" },
                    new Category { Name = "Sauces" },
                    new Category { Name = "Cheese" },
                    new Category { Name = "Proteins" },
                    new Category { Name = "Drinks" },
                    new Category { Name = "Snacks" },
                    new Category { Name = "Desserts" }
                );

                context.SaveChanges();
            }

            if (!context.Products.Any())
            {
                context.Products.AddRange(

                    new Product { Name = "Whole Wheat Bread", Price = 25.00m, CategoryId = 1 },
                    new Product { Name = "Light Bread", Price = 20.00m, CategoryId = 1 },
                    new Product { Name = "Cheese Bread", Price = 22.00m, CategoryId = 1 },
                    new Product { Name = "White Bread", Price = 18.00m, CategoryId = 1 },
                    new Product { Name = "Focaccia", Price = 30.00m, CategoryId = 1 },

                    new Product { Name = "Ham", Price = 15.00m, CategoryId = 2 },
                    new Product { Name = "Turkey", Price = 20.00m, CategoryId = 2 },
                    new Product { Name = "Beef", Price = 30.00m, CategoryId = 2 },
                    new Product { Name = "Chicken", Price = 25.00m, CategoryId = 2 },
                    new Product { Name = "Vegetarian", Price = 18.00m, CategoryId = 2 },
                    new Product { Name = "Tuna", Price = 22.00m, CategoryId = 2 },

                    new Product { Name = "Cheddar", Price = 10.00m, CategoryId = 5 },
                    new Product { Name = "Mozzarella", Price = 12.00m, CategoryId = 5 },
                    new Product { Name = "Hard Cheese", Price = 14.00m, CategoryId = 5 },

                    new Product { Name = "Mayonnaise", Price = 5.00m, CategoryId = 4 },
                    new Product { Name = "Mustard", Price = 4.00m, CategoryId = 4 },
                    new Product { Name = "Barbecue Sauce", Price = 6.00m, CategoryId = 4 },
                    new Product { Name = "Sweet Chili", Price = 6.00m, CategoryId = 4 },
                    new Product { Name = "Ranch Sauce", Price = 5.00m, CategoryId = 4 },

                    new Product { Name = "Tomato", Price = 5.00m, CategoryId = 3 },
                    new Product { Name = "Onion", Price = 3.00m, CategoryId = 3 },
                    new Product { Name = "Bell Pepper", Price = 6.00m, CategoryId = 3 },
                    new Product { Name = "Cucumber", Price = 4.00m, CategoryId = 3 },
                    new Product { Name = "Spinach", Price = 5.00m, CategoryId = 3 },

                    new Product { Name = "Coca-Cola", Price = 15.00m, CategoryId = 7 },
                    new Product { Name = "Fanta", Price = 15.00m, CategoryId = 7 },
                    new Product { Name = "Sprite", Price = 15.00m, CategoryId = 7 },
                    new Product { Name = "Water", Price = 10.00m, CategoryId = 7 },

                    new Product { Name = "Chocolate Chip Cookies", Price = 12.00m, CategoryId = 6 },
                    new Product { Name = "Cookie", Price = 10.00m, CategoryId = 6 },

                    new Product { Name = "Lays Original", Price = 10.00m, CategoryId = 8 },
                    new Product { Name = "Lays Paprika", Price = 10.00m, CategoryId = 8 }
                );

                context.SaveChanges();
            }


        }


    }

}
