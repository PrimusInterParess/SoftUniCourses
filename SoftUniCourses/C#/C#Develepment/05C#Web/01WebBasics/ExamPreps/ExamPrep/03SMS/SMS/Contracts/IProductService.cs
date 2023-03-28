using System.Collections.Generic;
using SMS.Models.Products;

namespace SMS.Contracts;

public interface IProductService
{
    (bool isValid, string errors) Create(CreateProductViewModel model);

    List<ProductListViewModel> GetProducts();

}