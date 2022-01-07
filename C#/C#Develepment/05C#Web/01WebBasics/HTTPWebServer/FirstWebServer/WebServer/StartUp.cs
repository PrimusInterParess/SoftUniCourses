

using System.Text;
using WebServer.Controllers;
using WebServer.Server.Http;
using WebServer.Server.Responses;

namespace WebServer
{
    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Threading.Tasks;
    using WebServer.Server;

    // localhost 127.0.0.1

    public class StartUp
    {
        private const string IpAddress = "127.0.0.1";
        private const int port = 5000;

        public static async Task Main()
            =>await new HttpServer(routs=>routs
                .MapGet("/", new HtmlResponse("<h1>hello from Here!</h1>"))
                .MapGet("/Cats", request =>
                {
                    const string nameKey = "Name";

                    var query = request.Query;
                    var catName = query.ContainsKey(nameKey)
                        ?query[nameKey] : 
                        "the cats";

                    var result = $"<h1>Hello from {catName}!</h1>";


                   return  new HtmlResponse(result);
                }))
                .Start();


        
    }
}
 