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

             return View(new
            {
                row = products,
                IsAuthenticated = true
            }, "/Carts/Details");
        }

        //public Response MyCart()
        //{
        //    return Redirect("/Carts/Details");
        //}

        [Authorize]
        public Response Buy()
        {
           var userId =  this.User.Id;

          var result = this.cartService.ClearCard(userId);

          if (result==true)
          {
              return Redirect("/");
          }

          return View(new { ErrorMessage = "Could not finish purchase!" },"/Error");
        }
    }
}
