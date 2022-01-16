

using System.Text;
using WebServer.Server.Controllers;
using WebServer.Server;
using WebServer.Server.Http;
using WebServer.Server.Responses;

namespace WebServer
{
    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Threading.Tasks;
    using WebServer.Server.Controllers;
    

    // localhost 127.0.0.1

    public class StartUp
    {
        private const string IpAddress = "127.0.0.1";
        private const int port = 5000;

        public static async Task Main()
            =>await new HttpServer(routes=>routes
                    .MapGet<HomeController>("/",c=>c.Index())
                    .MapGet<AnimalsController>("/Cats", c=>c.Cats()))
                .Start();


        
    }
}
 