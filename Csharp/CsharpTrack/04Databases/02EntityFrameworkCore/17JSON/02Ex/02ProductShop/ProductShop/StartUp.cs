using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.DataTranferObjects;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        private static IMapper Mapper;

        public static void Main(string[] args)
        {
            var db = new ProductShopContext();

            //db.Database.EnsureDeleted();
            //db.Database.EnsureCreated();

            //string userJson = File.ReadAllText("../../../Datasets/users.json");
            //string productJson = File.ReadAllText("../../../Datasets/products.json");
            //string categoriesJson = File.ReadAllText("../../../Datasets/categories.json");
            //string categoryProductsJson = File.ReadAllText("../../../Datasets/categories-products.json");

            //string usersImported = ImportUsers(db, userJson);

            //string productImport = ImportProducts(db, productJson);

            //string categoriesImport = ImportCategories(db, categoriesJson);

            //string categoryProductsImport = ImportCategoryProducts(db, categoryProductsJson);

         //   string productsInRange = GetProductsInRange(db);

          //  string soldProducts = GetSoldProducts(db);

            string categoriesByProductsCount = GetCategoriesByProductsCount(db);

         //   string usersWithProducts = GetUsersWithProducts(db);

        }


        public static string GetUsersWithProducts(ProductShopContext context)
        {



            var users = context
                .Users
                .Include(x=>x.ProductsSold)
                .ToArray()
                .Where(u => u.ProductsSold.Any(p => p.BuyerId != null))
                .Select(u => new
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    age = u.Age,
                    soldProducts = new
                    {
                        count = u.ProductsSold.Where(prd=>prd.BuyerId!=null).Count(),
                        products = u.ProductsSold.Where(x => x.BuyerId != null).Select(p => new
                        {
                            name = p.Name,
                            price = p.Price
                        })
                    }
                })
                .OrderByDescending(u => u.soldProducts.products.Count())
                .ToList();



            var resu = new
            {
                usersCount = users.Count(),
                users = users
            };

            var settings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            };

            var res = JsonConvert.SerializeObject(resu, settings);

            return res;
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context
                .Categories
                .ToArray()
                .Select(c => new
                {
                    category = c.Name,
                    productsCount = c.CategoryProducts.Select(p => p.ProductId).Count(),
                    averagePrice = c.CategoryProducts.Select(p => p.Product.Price).Average().ToString("f2"),
                    totalRevenue = c.CategoryProducts.Select(p => p.Product.Price).Sum().ToString("f2")

                })
                .OrderByDescending(c => c.productsCount)
                .ToList();


            string result = JsonConvert.SerializeObject(categories, Formatting.Indented);

            return result;
        }


        public static string GetSoldProducts(ProductShopContext context)
        {

            var sellers = context
                .Users
                .Where(u => u.ProductsSold.Any(p => p.BuyerId != null))
                .Select(u => new
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    soldProducts = u.ProductsSold.Where(p => p.BuyerId != null).Select(p => new
                    {
                        name = p.Name,
                        price = p.Price,
                        buyerFirstName = p.Buyer.FirstName,
                        buyerLastName = p.Buyer.LastName,

                    }).ToList()
                })
                .OrderBy(u => u.lastName)
                .ThenBy(u => u.firstName)
                .ToList();


            string result = JsonConvert.SerializeObject(sellers, Formatting.Indented);

            return result;


        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var productsInRange = context
                .Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .Select(p =>
                    new
                    {
                        name = p.Name,
                        price = p.Price,
                        seller = p.Seller.FirstName + " " + p.Seller.LastName
                    })
                .OrderBy(p => p.price)
                .ToList();

            var res = JsonConvert.SerializeObject(productsInRange, Formatting.Indented);

            return res;

        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            InitializeAutoMapper();

            var dboCategoryProducts = JsonConvert
                .DeserializeObject<IEnumerable<CategoryProductsInputModel>>(inputJson);

            var categoryProducts = Mapper
                .Map<IEnumerable<CategoryProduct>>(dboCategoryProducts);

            context.CategoryProducts.AddRange(categoryProducts);

            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count()}";

        }


        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            InitializeAutoMapper();

            var dtoCategories = JsonConvert
                .DeserializeObject<IEnumerable<CategoryInputModel>>(inputJson)
                .Where(c => c.Name != null)
                .ToList();

            var categories = Mapper
                .Map<IEnumerable<Category>>(dtoCategories);

            context.Categories.AddRange(categories);

            context.SaveChanges();

            return $"Successfully imported {categories.Count()}";

        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            InitializeAutoMapper();

            var dtoProducts = JsonConvert
                .DeserializeObject<IEnumerable<ProductInputModel>>(inputJson);

            var products = Mapper
                .Map<Product[]>(dtoProducts);

            context.Products.AddRange(products);

            context.SaveChanges();

            return $"Successfully imported {products.Count()}";

        }


        public static string ImportUsers(ProductShopContext context, string inputJson)
        {

            InitializeAutoMapper();


            var dtoUsers = JsonConvert
                .DeserializeObject<IEnumerable<UserInputModel>>(inputJson);

            var users = Mapper.Map<User[]>(dtoUsers);

            context.Users.AddRange(users);

            context.SaveChanges();

            return $"Successfully imported {users.Count()}";
        }


        private static void InitializeAutoMapper()
        {

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            });

            Mapper = config.CreateMapper();
        }
    }
}