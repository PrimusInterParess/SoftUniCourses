using Microsoft.EntityFrameworkCore;
using SMS.Contracts;
using SMS.Data.Common;
using SMS.Data.Models;
using SMS.Models.Carts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Services
{
    public class CartService : ICartService
    {

        private readonly IRepository repo;
       

        public CartService(IRepository repo)
        {
            this.repo = repo;
        }
        public IEnumerable<CartViewModel> AddProduct(string productId,string userId)
        {
           
            var user = repo.All<User>()
                .Where(u => u.Id == userId)
                .Include(u => u.Cart)
                .ThenInclude(c => c.Products)
                .FirstOrDefault();

            var product = repo
               .All<Product>()
               .FirstOrDefault(p => p.Id == productId);


            user.Cart.Products.Add(product);

            try
            {
                repo.SaveChanges();
            }
            catch
            { }

            return user
                .Cart
                .Products
                .Select(p => new CartViewModel
                {
                    ProductName = p.Name,
                    ProductPrice = p.Price.ToString("f2")
                });
           
        }

        public IEnumerable<CartViewModel> GetProducts(string id)
        {
            var user= this
                .repo.All<User>()
                .Where(u => u.Id == id)
                .Include(u => u.Cart)
                .ThenInclude(c => c.Products)
                .FirstOrDefault();

            return user.Cart.Products.Select(p => new CartViewModel
            {
                ProductName = p.Name,
                ProductPrice = p.Price.ToString("f2")
            });
        }

        public bool ClearCard(string userId)
        {

            var cartCleared = true;

            var user = this
                .repo.All<User>()
                .Where(u => u.Id == userId)
                .Include(u => u.Cart)
                .ThenInclude(c => c.Products)
                .FirstOrDefault();

            user.Cart.Products.Clear();


            try
            {
                repo.SaveChanges();
                return true;

            }
            catch (Exception)
            {
                cartCleared = false;
            }

            return cartCleared;

        }
    }
}
