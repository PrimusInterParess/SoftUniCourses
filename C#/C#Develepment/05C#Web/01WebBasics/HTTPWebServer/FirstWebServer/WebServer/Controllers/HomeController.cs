using WebServer.Server;
using WebServer.Server.Http;
using WebServer.Server.Responses;

namespace WebServer.Server.Controllers
{
    public class HomeController:Controller
    {
        private readonly HttpRequest request;

        public HomeController(HttpRequest request)
        :base(request)
        {
        }

        public HttpResponse Index()
        {
            return Text("<h1>Hello from the HomePage!</h1>");
        }
    }
}