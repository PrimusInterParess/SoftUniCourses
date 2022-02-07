﻿using System;
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


        private const string LogInForm = @"<form action ='/Login' method='POST'>
                                           Username: <input type='text' name='Username'/>
                                           Password:<input type='text' name='Password'/>
                                           <input type='submit' value='Log In' />
                                           </form>";

        private const string Username = "user";

        private const string Password = "user123";



        public static async Task Main(string[] args)
            => await new HttpServer(routes => routes
                     .MapGet<HomeController>("/", c => c.Index())
                    .MapGet<HomeController>("/Redirect", c => c.Redirect())
                    .MapGet<HomeController>("/HTML", c => c.Html())
                     .MapPost<HomeController>("/HTML", c => c.HtmlFormPost())
                    .MapGet<HomeController>("/Content", c => c.Content())

             .MapPost<HomeController>("/Content", c => c.DownloadContent())
             //.MapGet<HomeController>("/Cookies", c => c.Cookies())
             //.MapGet<HomeController>("/Session",c=>c.Session()))
             ).Start();

        // .MapGet<HomeController>("/Login", new HtmlResponse(StartUp.LogInForm))
        // .MapPost<HomeController>("/Login", new HtmlResponse("", StartUp.LoginAction))
        // .MapGet<HomeController>("/UserProfile", new HtmlResponse("", StartUp.GetUserDataAction))


        private static void GetUserDataAction(Request request, Response response)
        {

            if (request.Session.ContainsKey(Session.SessionUserKey))
            {
                response.Body = string.Empty;
                response.Body += $"<h3>Currently logged-in user" + $"is with username'{Username}'</h3>";
            }
            else
            {
                response.Body = string.Empty;
                response.Body += "<h3>You should first log in " + "- <a href='/Login'>Login</a></h3>";
            }
        }

        private static void DisplaySessionInfoAction(Request request, Response response)
        {
            var sessionExists = request.Session.ContainsKey(Session.SessionCurrentDateKey);

            var bodyText = string.Empty;

            if (sessionExists)
            {
                var currentDate = request.Session[Session.SessionCurrentDateKey];
                bodyText = $"Stored date:{currentDate}!";
            }
            else
            {
                bodyText = "Current date stored!";
            }

            response.Body = string.Empty;
            response.Body += bodyText;
        }


        private static void LoginAction(Request request, Response response)
        {
            request.Session.Clear();
            var bodyText = string.Empty;
            var usernameMatches = request.Form["Username"] == StartUp.Username;
            var passwordMatches = request.Form["Password"] == StartUp.Password;

            if (usernameMatches && passwordMatches)
            {
                request.Session[Session.SessionUserKey] = "MyUserId";
                response.Cookies.Add(Session.SessionCookieName, request.Session.Id);

                bodyText = "<h3>Logged successfully!</h3>";
            }
            else
            {
                bodyText = StartUp.LogInForm;
            }

            response.Body = string.Empty;
            response.Body += bodyText;

        }





        private static void AddCookiesAction(Request request, Response response)
        {
            var requestHasCookies = request.Cookies.Any(c => c.Name != Session.SessionCookieName);

            var bodyText = "";

            if (requestHasCookies)
            {
                var cookieText = new StringBuilder();
                cookieText
                    .AppendLine("<h1>Cookies</h1>");

                cookieText
                    .Append("<table border='1'><tr><th>Name</th><th>Value</th></tr>");

                foreach (var cookie in request.Cookies)
                {
                    cookieText
                        .Append("<tr>");
                    cookieText
                        .Append($"<td>{HttpUtility.HtmlEncode(cookie.Name)}</td>");
                    cookieText
                        .Append($"<td>{HttpUtility.HtmlEncode(cookie.Value)}</td>");
                    cookieText
                        .Append("</tr>");
                }

                cookieText
                    .Append("</table>");

                bodyText = cookieText.ToString();
            }
            else
            {
                bodyText = "<h1>Cookies set!</h1>";

                response.Cookies.Add("My-Cookie", "My-Value");
                response.Cookies.Add("My-Second-Cookie", "My-Second-Value");
            }

            response.Body = bodyText;
        }
    }
}
