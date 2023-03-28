using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using SMS.Contracts;
using SMS.Data.Common;
using SMS.Data.Models;
using SMS.Models.Products;

namespace SMS.Services
{
    public class ProductService : IProductService
    {
        private readonly IValidationService validation;
        private readonly IRepository repo;
        public ProductService(IValidationService validation, IRepository repo)
        {
            this.validation = validation;
            this.repo = repo;
        }

        public (bool isValid, string errors) Create(CreateProductViewModel model)
        {

            var created = false;
            var error = string.Empty;

            var (isValid, errors) =
                validation.ValidateModel(model);

            decimal price = 0;

            if (!decimal.TryParse(
                model.Price,
                NumberStyles
                .AllowDecimalPoint,
                CultureInfo.InvariantCulture,
                out price)||
                price<0.05m ||
                price>1000m)
            {
                return (false,"Invalid price.Price range 0.05,1000");
            }

            if (isValid == false)
            {
                return (isValid, errors);
            }


            Product product = new Product()
            {
                Name = model.Name,
                Price = price
            };

            try
            {
                repo.Add(product);
                repo.SaveChanges();

                created = true;

            }
            catch (Exception)
            {
                error = "Could not save Product";
            }

            return (created, error);

        }

    
        public List<ProductListViewModel> GetProducts()
        {
            return repo.All<Product>().Select(p => new ProductListViewModel()
            {
                ProductId = p.Id,
                ProductPrice = p.Price.ToString("F"),
                ProductName = p.Name
            }).ToList();
        }
    }
}
