using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using SMS.Contracts;

namespace SMS.Controllers
{
    public class CartsController : Controller
    {

        private readonly ICartService cartService;


        public CartsController(Request request,ICartService cartService) : base(request)
        {
            this.cartService = cartService;
        }

        [Authorize]
        public Response AddProduct(string productId)
        {
            var resultProducts = cartService.AddProduct(productId, this.User.Id);

            return View(new
            {
                row = resultProducts,
                IsAuthenticated = true
            },"/Carts/Details") ;
        }

        [Authorize]
        public Response Details()
        {
            var products = cartService.GetProducts(this.User.Id);

            return View(products, "/Cats/Details");
        }
    }
}
