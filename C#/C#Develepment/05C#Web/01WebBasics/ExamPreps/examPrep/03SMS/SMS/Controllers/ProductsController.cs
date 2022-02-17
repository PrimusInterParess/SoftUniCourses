using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using SMS.Contracts;
using SMS.Models.Products;

namespace SMS.Controllers
{
    public class ProductsController:Controller
    {
        private readonly IProductService productService;

        public ProductsController(Request request,
            IProductService productService) 
            : base(request)
        {
            this.productService = productService;
        }

        [Authorize]
        public Response Create()
        {
            return View( new { IsAuthenticated =true});
        }

   
        [HttpPost]
        public Response Create(CreateProductViewModel model)
        {
            var (created, error) = productService.Create(model);


            if (created==false)
            {
                return View(new { ErrorMessage = error }, "/Error");
            }

            return Redirect("/");

        }
    }
}
