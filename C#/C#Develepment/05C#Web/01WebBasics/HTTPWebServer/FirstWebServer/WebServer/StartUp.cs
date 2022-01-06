

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
                .MapGet("/", new TextResponse("hello from Here!"))
                .MapGet("/Cats",new TextResponse("Hello from the cats!")))
                .Start();


        
    }
}
 