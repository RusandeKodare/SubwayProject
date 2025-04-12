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
                    new Category { Name = "Sub" },
                    new Category { Name = "Drinks" },
                    new Category { Name = "Snacks" },
                    new Category { Name = "Desserts" }
                );

                context.SaveChanges();
            }

            if (!context.SubCategories.Any())
            {

                context.SubCategories.AddRange(
                    new SubCategory { Name = "Bread", CategoryId = 1 },
                    new SubCategory { Name = "Vegetables", CategoryId = 1 },
                    new SubCategory { Name = "Sauces", CategoryId = 1 },
                    new SubCategory { Name = "Cheese", CategoryId = 1 },
                    new SubCategory { Name = "Proteins", CategoryId = 1 },
                    new SubCategory { Name = "Carbonated", CategoryId = 2},
                    new SubCategory { Name = "Non Carbonated", CategoryId = 2},
                    new SubCategory { Name = "Chips", CategoryId = 3},
                    new SubCategory { Name = "Cookies", CategoryId = 3},
                    new SubCategory { Name = "Ice-Cream", CategoryId = 4},
                    new SubCategory { Name = "Pies", CategoryId = 4}
                    );

                context.SaveChanges();

            }

            if (!context.Products.Any())
            {
                context.Products.AddRange(

                    new Product { Name = "White Bread", Price = 15.00m, SubCategoryId = 1, ImageUrl = "https://okfrozendough.com/wp-content/uploads/2019/10/OK340_9_inc_white_bun.jpg" },
                    new Product { Name = "Whole Wheat Bread", Price = 20.00m, SubCategoryId = 1, ImageUrl = "https://okfrozendough.com/wp-content/uploads/2019/10/OK345_9_inc_ww_sub_bun.jpg" },
                    new Product { Name = "Light Bread", Price = 18.00m, SubCategoryId = 1, ImageUrl = "https://www.seasonsandsuppers.ca/wp-content/uploads/2022/09/sub-rolls-4-3-3.jpg" },
                    new Product { Name = "Cheese Bread", Price = 33.00m, SubCategoryId = 1, ImageUrl = "https://cdn.vox-cdn.com/thumbor/v5MOxdUdtffU4E1zkMM80jetZ2c=/0x0:1080x1350/1200x800/filters:focal(477x802:649x974)/cdn.vox-cdn.com/uploads/chorus_image/image/72447167/358101373_292422893350341_630677683818333789_n.0.jpg" },
                    

                    new Product { Name = "Tomato", Price = 5.00m, SubCategoryId = 2, ImageUrl = "https://m.economictimes.com/thumb/msid-95423731,width-1200,height-900,resizemode-4,imgsize-56196/tomatoes-canva.jpg" },
                    new Product { Name = "Onion", Price = 3.00m, SubCategoryId = 2, ImageUrl= "https://ih1.redbubble.net/image.3804311069.0627/raf,360x360,075,t,fafafa:ca443f4786.jpg" },
                    new Product { Name = "Bell Pepper", Price = 6.00m, SubCategoryId = 2, ImageUrl= "https://www.chilipeppermadness.com/wp-content/uploads/2024/02/Bell-Peppers1.jpg" },
                    new Product { Name = "Cucumber", Price = 4.00m, SubCategoryId = 2, ImageUrl= "https://snaped.fns.usda.gov/sites/default/files/styles/crop_ratio_7_5/public/seasonal-produce/2018-05/cucumbers2.jpg.webp?itok=Y2CZseBE" },
                    new Product { Name = "Spinach", Price = 5.00m, SubCategoryId = 2, ImageUrl = "https://bedford.tennessee.edu/wp-content/uploads/sites/162/2020/08/spinach-leaves-1024x593.jpg" },

                    new Product { Name = "Mayonnaise", Price = 5.00m, SubCategoryId = 3, ImageUrl = "https://media.istockphoto.com/id/507636140/photo/homemade-mayonnaise.jpg?s=612x612&w=0&k=20&c=Yo39cXtQ0x4uRJbRKMo__9ppA-BKcLI82PbMcn4aweo=" },
                    new Product { Name = "Mustard", Price = 4.00m, SubCategoryId = 3, ImageUrl = "https://www.realsimple.com/thmb/vPbhjHFdv4Ta_YuujhhHSzsKPL8=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/homemade-mustard-2000-178458cea0514bdfa3bcfb4cd499612b.jpg" },
                    new Product { Name = "Barbecue Sauce", Price = 6.00m, SubCategoryId = 3, ImageUrl = "https://www.allrecipes.com/thmb/N3b7R0ApzKN6q0RRLQdmb6KPegQ=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/51226-a-very-popular-bbq-sauce-DDMFS-4x3-c6e3230c5df240b4937385141cce0b67.jpg" },
                    new Product { Name = "Sweet Chili", Price = 6.00m, SubCategoryId = 3, ImageUrl = "https://www.foxyfolksy.com/wp-content/uploads/2021/10/sweet-chili-sauce-1200t.jpg" },
                    new Product { Name = "Ranch Sauce", Price = 5.00m, SubCategoryId = 3, ImageUrl = "https://taoofspice.com/wp-content/uploads/2022/01/Close-up-of-garlic-ranch-dip-with-carrots-surrounding-it-683x1024.jpg.webp" },


                    new Product { Name = "Cheddar", Price = 10.00m, SubCategoryId = 4, ImageUrl = "https://i.guim.co.uk/img/media/02088fb2247b13df646907d47f552dc69a236bc7/0_93_3235_3304/master/3235.jpg?width=445&dpr=1&s=none&crop=none" },
                    new Product { Name = "Mozzarella", Price = 12.00m, SubCategoryId = 4, ImageUrl = "https://i.guim.co.uk/img/media/02088fb2247b13df646907d47f552dc69a236bc7/0_93_3235_3304/master/3235.jpg?width=445&dpr=1&s=none&crop=none" },
                    new Product { Name = "Hard Cheese", Price = 14.00m, SubCategoryId = 4, ImageUrl = "https://i.guim.co.uk/img/media/02088fb2247b13df646907d47f552dc69a236bc7/0_93_3235_3304/master/3235.jpg?width=445&dpr=1&s=none&crop=none" },

                    new Product { Name = "Ham", Price = 15.00m, SubCategoryId = 5, ImageUrl = "https://i.guim.co.uk/img/media/02088fb2247b13df646907d47f552dc69a236bc7/0_93_3235_3304/master/3235.jpg?width=445&dpr=1&s=none&crop=none" },
                    new Product { Name = "Turkey", Price = 20.00m, SubCategoryId = 5, ImageUrl = "https://i.guim.co.uk/img/media/02088fb2247b13df646907d47f552dc69a236bc7/0_93_3235_3304/master/3235.jpg?width=445&dpr=1&s=none&crop=none" },
                    new Product { Name = "Beef", Price = 30.00m, SubCategoryId = 5, ImageUrl = "https://i.guim.co.uk/img/media/02088fb2247b13df646907d47f552dc69a236bc7/0_93_3235_3304/master/3235.jpg?width=445&dpr=1&s=none&crop=none" },
                    new Product { Name = "Chicken", Price = 25.00m, SubCategoryId = 5, ImageUrl = "https://i.guim.co.uk/img/media/02088fb2247b13df646907d47f552dc69a236bc7/0_93_3235_3304/master/3235.jpg?width=445&dpr=1&s=none&crop=none" },
                    new Product { Name = "Vegetarian", Price = 18.00m, SubCategoryId = 5, ImageUrl = "https://i.guim.co.uk/img/media/02088fb2247b13df646907d47f552dc69a236bc7/0_93_3235_3304/master/3235.jpg?width=445&dpr=1&s=none&crop=none" },
                    new Product { Name = "Tuna", Price = 22.00m, SubCategoryId = 5, ImageUrl = "https://i.guim.co.uk/img/media/02088fb2247b13df646907d47f552dc69a236bc7/0_93_3235_3304/master/3235.jpg?width=445&dpr=1&s=none&crop=none" },
                    new Product { Name = "Chicken Breast", Price = 25.00m, SubCategoryId = 5, ImageUrl = "https://i.guim.co.uk/img/media/02088fb2247b13df646907d47f552dc69a236bc7/0_93_3235_3304/master/3235.jpg?width=445&dpr=1&s=none&crop=none" },
                    new Product { Name = "Steak", Price = 30.00m, SubCategoryId = 5, ImageUrl = "https://i.guim.co.uk/img/media/02088fb2247b13df646907d47f552dc69a236bc7/0_93_3235_3304/master/3235.jpg?width=445&dpr=1&s=none&crop=none" },
                    new Product { Name = "Tofu", Price = 18.00m, SubCategoryId = 5, ImageUrl = "https://i.guim.co.uk/img/media/02088fb2247b13df646907d47f552dc69a236bc7/0_93_3235_3304/master/3235.jpg?width=445&dpr=1&s=none&crop=none" },

                    new Product { Name = "Coca-Cola", Price = 15.00m, SubCategoryId = 6, ImageUrl = "https://i.guim.co.uk/img/media/02088fb2247b13df646907d47f552dc69a236bc7/0_93_3235_3304/master/3235.jpg?width=445&dpr=1&s=none&crop=none" },
                    new Product { Name = "Fanta", Price = 15.00m, SubCategoryId = 6, ImageUrl = "https://i.guim.co.uk/img/media/02088fb2247b13df646907d47f552dc69a236bc7/0_93_3235_3304/master/3235.jpg?width=445&dpr=1&s=none&crop=none" },
                    new Product { Name = "Sprite", Price = 15.00m, SubCategoryId = 6, ImageUrl = "https://i.guim.co.uk/img/media/02088fb2247b13df646907d47f552dc69a236bc7/0_93_3235_3304/master/3235.jpg?width=445&dpr=1&s=none&crop=none" },
                    new Product { Name = "Water", Price = 10.00m, SubCategoryId = 7, ImageUrl = "https://i.guim.co.uk/img/media/02088fb2247b13df646907d47f552dc69a236bc7/0_93_3235_3304/master/3235.jpg?width=445&dpr=1&s=none&crop=none" },

                    new Product { Name = "Lays Original", Price = 10.00m, SubCategoryId = 8, ImageUrl = "https://i.guim.co.uk/img/media/02088fb2247b13df646907d47f552dc69a236bc7/0_93_3235_3304/master/3235.jpg?width=445&dpr=1&s=none&crop=none" },
                    new Product { Name = "Lays Paprika", Price = 10.00m, SubCategoryId = 8, ImageUrl = "https://i.guim.co.uk/img/media/02088fb2247b13df646907d47f552dc69a236bc7/0_93_3235_3304/master/3235.jpg?width=445&dpr=1&s=none&crop=none" },

                    new Product { Name = "Chocolate Chip Cookies", Price = 12.00m, SubCategoryId = 9, ImageUrl = "https://i.guim.co.uk/img/media/02088fb2247b13df646907d47f552dc69a236bc7/0_93_3235_3304/master/3235.jpg?width=445&dpr=1&s=none&crop=none" },
                    new Product { Name = "Cookie", Price = 10.00m, SubCategoryId = 9, ImageUrl = "https://i.guim.co.uk/img/media/02088fb2247b13df646907d47f552dc69a236bc7/0_93_3235_3304/master/3235.jpg?width=445&dpr=1&s=none&crop=none" },
                    new Product { Name = "Brownie", Price = 15.00m, SubCategoryId = 9, ImageUrl = "https://i.guim.co.uk/img/media/02088fb2247b13df646907d47f552dc69a236bc7/0_93_3235_3304/master/3235.jpg?width=445&dpr=1&s=none&crop=none" },

                    new Product { Name = "Ice Cream", Price = 20.00m, SubCategoryId = 10, ImageUrl = "https://i.guim.co.uk/img/media/02088fb2247b13df646907d47f552dc69a236bc7/0_93_3235_3304/master/3235.jpg?width=445&dpr=1&s=none&crop=none" },

                    new Product { Name = "Apple Pie", Price = 18.00m, SubCategoryId = 11, ImageUrl = "https://i.guim.co.uk/img/media/02088fb2247b13df646907d47f552dc69a236bc7/0_93_3235_3304/master/3235.jpg?width=445&dpr=1&s=none&crop=none" },
                    new Product { Name = "Cheesecake", Price = 22.00m, SubCategoryId = 11, ImageUrl = "https://i.guim.co.uk/img/media/02088fb2247b13df646907d47f552dc69a236bc7/0_93_3235_3304/master/3235.jpg?width=445&dpr=1&s=none&crop=none" }
                );

                context.SaveChanges();
            }



        }


    }

}
