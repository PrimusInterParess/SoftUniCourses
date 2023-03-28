using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServer.Server.Http;
using WebServer.Server.Routing;

namespace WebServer.Server.Controllers
{
  public static class RoutingTableExtentions
  {

      public static IRoutingTable MapGet<TController>(
          this IRoutingTable routingTable,
          string path,
          Func<TController,
              HttpResponse> controllerFunction)
          where TController : Controller
          => routingTable.MapGet(path, request =>
          {
              var controller =(TController) Activator
                  .CreateInstance(typeof(TController), new[] { request });

              return controllerFunction(controller);
          });

       public static IRoutingTable MapPost<TController>(this IRoutingTable routingTable, string path, Func<TController, HttpResponse> controllerFunction)
           where TController : Controller
           => routingTable.MapPost(path, request =>
           {
               var controller = (TController)Activator
                   .CreateInstance(typeof(TController), new[] { request });

               return controllerFunction(controller);
           });

    }
}
