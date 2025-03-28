using subway_project.Server.Data;

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

                    new Product { Name = "Fullkornsbröd", Price = 25.00m, ImageUrl = "https://example.com/fullkornsbrod.jpg", CategoryId = 1 },
                    new Product { Name = "Ljust bröd", Price = 20.00m, ImageUrl = "https://example.com/ljustbrod.jpg", CategoryId = 1 },
                    new Product { Name = "Ostbröd", Price = 22.00m, ImageUrl = "https://example.com/ostbrod.jpg", CategoryId = 1 },
                    new Product { Name = "Vitt bröd", Price = 18.00m, ImageUrl = "https://example.com/vittbrod.jpg", CategoryId = 1 },
                    new Product { Name = "Focaccia", Price = 30.00m, ImageUrl = "https://example.com/focaccia.jpg", CategoryId = 1 },

                    new Product { Name = "Skinka", Price = 15.00m, ImageUrl = "https://example.com/skinka.jpg", CategoryId = 2 },
                    new Product { Name = "Kalkon", Price = 20.00m, ImageUrl = "https://example.com/kalkon.jpg", CategoryId = 2 },
                    new Product { Name = "Biff", Price = 30.00m, ImageUrl = "https://example.com/biff.jpg", CategoryId = 2 },
                    new Product { Name = "Kyckling", Price = 25.00m, ImageUrl = "https://example.com/kyckling.jpg", CategoryId = 2 },
                    new Product { Name = "Vegetariskt", Price = 18.00m, ImageUrl = "https://example.com/vegetariskt.jpg", CategoryId = 2 },
                    new Product { Name = "Tonfisk", Price = 22.00m, ImageUrl = "https://example.com/tonfisk.jpg", CategoryId = 2 },

                    new Product { Name = "Cheddar", Price = 10.00m, ImageUrl = "https://example.com/cheddar.jpg", CategoryId = 5 },
                    new Product { Name = "Mozzarella", Price = 12.00m, ImageUrl = "https://example.com/mozzarella.jpg", CategoryId = 5 },
                    new Product { Name = "Hårdost", Price = 14.00m, ImageUrl = "https://example.com/hardost.jpg", CategoryId = 5 },

                    new Product { Name = "Mayonnaise", Price = 5.00m, ImageUrl = "https://example.com/mayonnaise.jpg", CategoryId = 4 },
                    new Product { Name = "Senap", Price = 4.00m, ImageUrl = "https://example.com/senap.jpg", CategoryId = 4 },
                    new Product { Name = "Barbecuesås", Price = 6.00m, ImageUrl = "https://example.com/barbecuesas.jpg", CategoryId = 4 },
                    new Product { Name = "Sweet Chilli", Price = 6.00m, ImageUrl = "https://example.com/sweetchilli.jpg", CategoryId = 4 },
                    new Product { Name = "Ranchsås", Price = 5.00m, ImageUrl = "https://example.com/ranchsas.jpg", CategoryId = 4 },

                    new Product { Name = "Tomat", Price = 5.00m, ImageUrl = "https://example.com/tomat.jpg", CategoryId = 3 },
                    new Product { Name = "Lök", Price = 3.00m, ImageUrl = "https://example.com/lok.jpg", CategoryId = 3 },
                    new Product { Name = "Paprika", Price = 6.00m, ImageUrl = "https://example.com/paprika.jpg", CategoryId = 3 },
                    new Product { Name = "Gurka", Price = 4.00m, ImageUrl = "https://example.com/gurka.jpg", CategoryId = 3 },
                    new Product { Name = "Spinat", Price = 5.00m, ImageUrl = "https://example.com/spinat.jpg", CategoryId = 3 },

                    new Product { Name = "Coca-Cola", Price = 15.00m, ImageUrl = "https://example.com/coca-cola.jpg", CategoryId = 7 },
                    new Product { Name = "Fanta", Price = 15.00m, ImageUrl = "https://example.com/fanta.jpg", CategoryId = 7 },
                    new Product { Name = "Sprite", Price = 15.00m, ImageUrl = "https://example.com/sprite.jpg", CategoryId = 7 },
                    new Product { Name = "Vatten", Price = 10.00m, ImageUrl = "https://example.com/vatten.jpg", CategoryId = 7 },

                    new Product { Name = "Chocolate Chip Cookies", Price = 12.00m, ImageUrl = "https://example.com/cookies.jpg", CategoryId = 6 },
                    new Product { Name = "Kaka", Price = 10.00m, ImageUrl = "https://example.com/kaka.jpg", CategoryId = 6 },

                    new Product { Name = "Lays Original", Price = 10.00m, ImageUrl = "https://example.com/laysoriginal.jpg", CategoryId = 8 },
                    new Product { Name = "Lays Paprika", Price = 10.00m, ImageUrl = "https://example.com/layspaprika.jpg", CategoryId = 8 }
                );

                context.SaveChanges();
            }


            context.SaveChanges();
        }

        context.SaveChanges();
        }
}
}
}
