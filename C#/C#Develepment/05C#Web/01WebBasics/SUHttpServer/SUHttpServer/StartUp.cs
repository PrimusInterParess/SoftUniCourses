using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SUHttpServer
{
    public class StartUp
    {
        private const string iPAddress = "127.0.0.1";
        private const int port = 8080;

        static void Main(string[] args)
            => new HttpServer(routes => routes
                    .MapGet("/", new TextResponse("Hello from the server"))
                    .MapGet("/HTML", new HtmlResponse("<h1>HTML response</h1>"))
                    .MapGet("/Redirect", new RedirectResponse("https://softuni.org")))
                .Start();

    }
}
