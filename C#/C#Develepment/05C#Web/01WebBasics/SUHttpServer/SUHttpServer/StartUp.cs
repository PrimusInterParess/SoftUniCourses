using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using SUHttpServer.Demo.Controllers;
using SUHttpServer.HTTP;
using SUHttpServer.Responses;
using SUHttpServer.Server.HTTP;


namespace SUHttpServer
{
    public class StartUp
    {
        private const string iPAddress = "127.0.0.1";

        private const int port = 8080;




        public static async Task Main(string[] args)
            => await new HttpServer(routes => routes
                     .MapGet<HomeController>("/", c => c.Index())
                     .MapGet<HomeController>("/Redirect", c => c.Redirect())
                     .MapGet<HomeController>("/HTML", c => c.Html())
                     .MapPost<HomeController>("/HTML", c => c.HtmlFormPost())
                     .MapGet<HomeController>("/Content", c => c.Content())
                     .MapPost<HomeController>("/Content", c => c.DownloadContent())
                     .MapGet<HomeController>("/Cookies", c => c.Cookies())
                     .MapGet<HomeController>("/Session", c => c.Session())
                     .MapGet<UserController>("/Login", c => c.Login())
                     .MapPost<UserController>("/Login", c => c.LoginUser())
                     .MapGet<UserController>("/Logout", c => c.Logout())
                     .MapGet<UserController>("/UserProfile", c => c.GetUserData()))
             .Start();

    }
}
