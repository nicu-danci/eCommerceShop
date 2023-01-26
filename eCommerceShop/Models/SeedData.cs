//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.DependencyInjection;
//using eCommerceShop.Data;
//using System;
//using System.Linq;

//namespace eCommerceShop.Models
//{
//    public static class SeedData
//    {
//        public static void Initialize(IServiceProvider serviceProvider)
//        {
//            using (var context = new _context(
//                serviceProvider.GetRequiredService<
//                    DbContextOptions<context>>()))
//            {
//                // Look for any movies.
//                if (context.Products.Any())
//                {
//                    return;   // DB has been seeded
//                }
//                context.Products.AddRange(
//                    new Products
//                    {
//                        Name = "Dog bed",
//                        ProductColor = "Black",
//                        ProductTypes = "Cat",
//                        Price = 7.99M
//                    },
//                    new Products
//                    {
//                        Title = "Ghostbusters ",
//                        ReleaseDate = DateTime.Parse("1984-3-13"),
//                        Genre = "Comedy",
//                        Price = 8.99M
//                    },
//                    new Products
//                    {
//                        Title = "Ghostbusters 2",
//                        ReleaseDate = DateTime.Parse("1986-2-23"),
//                        Genre = "Comedy",
//                        Price = 9.99M
//                    },
//                    new Products
//                    {
//                        Title = "Rio Bravo",
//                        ReleaseDate = DateTime.Parse("1959-4-15"),
//                        Genre = "Western",
//                        Price = 3.99M
//                    }
//                );
//                context.SaveChanges();
//            }
//        }

//        private class _context
//        {
//            private DbContextOptions<context> dbContextOptions;

//            public _context(DbContextOptions<context> dbContextOptions)
//            {
//                this.dbContextOptions = dbContextOptions;
//            }
//        }
//    }
//}