using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using ProductShop.Data;
using ProductShop.Dtos.Export;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using StringReader = System.IO.StringReader;

namespace ProductShop
{
    public class StartUp
    {
        public static IMapper mapper;

        public static void Main(string[] args)
        {
            var db = new ProductShopContext();

            //db.Database.EnsureDeleted();

            //db.Database.EnsureCreated();

            //var userXml = File.ReadAllText("users.xml");

            //var productXml = File.ReadAllText("products.xml");

            //var categoryXml = File.ReadAllText("categories.xml");

            //var categoryProductXml = File.ReadAllText("categories-products.xml");

            //string userImport = ImportUsers(db, userXml);

            //string productsImport = ImportProducts(db, productXml);

            //string categoriesImport = ImportCategories(db, categoryXml);

            //string categoryProduct = ImportCategoryProducts(db, categoryProductXml);

            //string productsInRange500_1000 = GetProductsInRange(db);

            //   string usersWithSoldItem = GetSoldProducts(db);

            //string categoriesWithProductCount = GetCategoriesByProductsCount(db);

            string usersWithProducts = GetUsersWithProducts(db);
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var usersNProducts = context.Users.Where(u => u.ProductsSold.Count > 0)

            var xmlSerializerNameSpace = new XmlSerializerNamespaces();
            xmlSerializerNameSpace.Add("", "");

            var textWriter = new StringWriter();

            var xmlSerializer =
                new XmlSerializer(typeof(UPEM), new XmlRootAttribute("Users"));


            xmlSerializer.Serialize(textWriter, res, xmlSerializerNameSpace);

            string result = textWriter.GetStringBuilder().ToString();

            return result;
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categoriesCount = context
                .Categories
                .Include(c => c.CategoryProducts)
                .Select(c => new CategoryCountExportModel()
                {
                    Name = c.Name,
                    Count = c.CategoryProducts.Count,
                    AveragePrice = c.CategoryProducts.Select(p => p.Product.Price).Average(),
                    TotalRevenue = c.CategoryProducts.Select(p => p.Product.Price).Sum()
                })

                .OrderByDescending(c => c.Count)
                .ThenBy(c => c.TotalRevenue)
                .ToList();


            var nameSpace = new XmlSerializerNamespaces();
            nameSpace.Add("", "");

            var xmlSerializer =
                new XmlSerializer(typeof(List<CategoryCountExportModel>), new XmlRootAttribute("Categories"));

            var textWriter = new StringWriter();

            var xmlSerializerNameSpace = new XmlSerializerNamespaces();
            xmlSerializerNameSpace.Add("", "");

            xmlSerializer.Serialize(textWriter, categoriesCount, xmlSerializerNameSpace);

            string result = textWriter.GetStringBuilder().ToString();

            return result;
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            /*
             * Get all users who have at least 1 sold item. Order them by last name, then by first name.
             * Select the person's first and last name.
             * For each of the sold products, select the product's name and price. Take top 5 records. 
             */

            /*
             * <Users>
               <User>
                 <firstName>Almire</firstName>
                 <lastName>Ainslee</lastName>
                 <soldProducts>

             */

            var usersWithSoldProducts = context
                .Users
                .Where(p => p.ProductsSold.Count > 0)
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Take(5)
                .Select(u => new UserWithSoldProductsExportModel()
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    SoldProducts = u.ProductsSold.Select(p => new ProductExportModel()
                    {
                        Name = p.Name,
                        Price = p.Price
                    }).ToList()
                })

                .ToList();

            var nameSpace = new XmlSerializerNamespaces();
            nameSpace.Add("", "");

            var xmlSerializer =
            new XmlSerializer(typeof(List<UserWithSoldProductsExportModel>), new XmlRootAttribute("Users"));

            var textWriter = new StringWriter();

            var xmlSerializerNameSpace = new XmlSerializerNamespaces();
            xmlSerializerNameSpace.Add("", "");

            xmlSerializer.Serialize(textWriter, usersWithSoldProducts, xmlSerializerNameSpace);

            string result = textWriter.GetStringBuilder().ToString();

            return result;
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var productsInRange = context
                .Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .Select(p => new ProductInRangeExportModel()
                {
                    Name = p.Name,
                    Price = p.Price,
                    Buyer = p.Buyer.FirstName + " " + p.Buyer.LastName
                })
                .OrderBy(p => p.Price)
                .Take(10)
                .ToList();

            var xmlSerializer =
                new XmlSerializer(typeof(List<ProductInRangeExportModel>), new XmlRootAttribute("Products"));

            var textWriter = new StringWriter();

            var xmlSerializerNameSpace = new XmlSerializerNamespaces();
            xmlSerializerNameSpace.Add("", "");

            xmlSerializer.Serialize(textWriter, productsInRange, xmlSerializerNameSpace);
            /*
             * var serializer = new XmlSerializer(typeof(ProductDTO));
               using (var writer = new StreamWriter("myProduct.xml");)
               {
                 serializer.Serialize(writer, product);
               }

             */

            string result = textWriter.ToString();

            return result;
        }


        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {

            InitializeAutoMapper();

            var categoriesIdsList = context.Categories.Select(c => c.Id).ToList();

            var productsIdsList = context.Products.Select(p => p.Id).ToList();

            var serializer = new XmlSerializer(typeof(CategoryProductInputModel[]), new XmlRootAttribute("CategoryProducts"));

            StringReader reader = new StringReader(inputXml);

            CategoryProductInputModel[] categoriesDbo = (CategoryProductInputModel[])serializer.Deserialize(reader);

            //categoriesDbo = categoriesDbo
            //    .Where(p => categoriesIdsList.Contains(p.CategoryId) && productsIdsList.Contains(p.ProductId))
            //    .ToArray();


            //  var categoryProducts = mapper.Map<CategoryProduct[]>(categoriesDbo)
            //.Where(x => categoriesIdsList.Any(c => c == x.CategoryId) && productsIdsList.Any(p => p == x.ProductId));


            ICollection<CategoryProduct> categoriesProducts = mapper
                .Map<CategoryProduct[]>(categoriesDbo)
                .Where(cp =>
                   categoriesIdsList.Contains(cp.CategoryId) &&
                   productsIdsList.Contains(cp.ProductId)).ToArray();

            //ICollection<Part> parts = Mapper
            //    .Map<ICollection<Part>>(dtoParts)
            //    .Where(p => suppliersIds.Contains(p.SupplierId))
            //    .ToList();


            context.CategoryProducts.AddRange(categoriesProducts);

            context.SaveChanges();

            return $"Successfully imported {categoriesDbo.Count()}";


        }

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            InitializeAutoMapper();

            var serializer = new XmlSerializer(typeof(CategoryInputModel[]), new XmlRootAttribute("Categories"));

            StringReader reader = new StringReader(inputXml);

            CategoryInputModel[] categoriesDbo = (CategoryInputModel[])serializer.Deserialize(reader);

            ICollection<Category> categories = mapper.Map<Category[]>(categoriesDbo);

            context.Categories.AddRange(categories);

            context.SaveChanges();

            return $"Successfully imported {categories.Count}";


        }

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            InitializeAutoMapper();

            var serializer = new XmlSerializer(typeof(ProductInputModel[]), new XmlRootAttribute("Products"));

            StringReader reader = new StringReader(inputXml);

            ProductInputModel[] productsDbo = (ProductInputModel[])serializer.Deserialize(reader);

            ICollection<Product> products = mapper.Map<Product[]>(productsDbo);

            context.Products.AddRange(products);

            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            InitializeAutoMapper();

            var serializer = new XmlSerializer(typeof(UserInputModel[]), new XmlRootAttribute("Users"));

            StringReader reader = new StringReader(inputXml);

            UserInputModel[] usersDbo = (UserInputModel[])serializer.Deserialize(reader);

            ICollection<User> users = mapper.Map<User[]>(usersDbo);

            context.Users.AddRange(users);

            context.SaveChanges();

            return $"Successfully imported {users.Count}";

        }

        private static void InitializeAutoMapper()
        {

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            });

            mapper = config.CreateMapper();
        }
    }
}