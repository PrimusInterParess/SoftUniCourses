using System;
using System.Collections.Generic;
using WebServer.Server.Common;
using WebServer.Server.Http;
using WebServer.Server.Responses;

namespace WebServer.Server.Routing
{
    public class RoutingTable : IRoutingTable
    {

        private readonly Dictionary<HttpMethod, Dictionary<string, Func<HttpRequest,HttpResponse>>> routes;

        public RoutingTable()
        {
            this.routes = new Dictionary<HttpMethod, Dictionary<string, Func<HttpRequest, HttpResponse>>>()
            {
                [HttpMethod.Get] = new (),
                [HttpMethod.Put] = new (),
                [HttpMethod.Post] = new (),
                [HttpMethod.Delete] = new(),
            };
        }

        public IRoutingTable Map(HttpMethod method, string path, HttpResponse response)
        {


            Guard.AgainstNull(path, nameof(path));
            Guard.AgainstNull(response, nameof(response));

            this.routes[method][path] = response;

            return this;


        }

       

        public IRoutingTable Map(string path, Func<HttpRequest, HttpResponse> responseFunc)
        {
            throw new NotImplementedException();
        }

      

        public IRoutingTable MapGet(string path, Func<HttpRequest, HttpResponse> responseFunc)
        {
            throw new NotImplementedException();
        }


        public IRoutingTable MapGet(string path, HttpResponse response)
            => Map(HttpMethod.Get, path, response);

        public IRoutingTable MapPost(string path, HttpResponse response)
        {
            throw new NotImplementedException();
        }

        public IRoutingTable MapPost(string path, Func<HttpRequest, HttpResponse> responseFunc)
        {
            throw new NotImplementedException();
        }


        public IRoutingTable MapPost(HttpResponse response, string path)
            => Map(HttpMethod.Post, path, response);


        public HttpResponse MatchRequest(HttpRequest request)
        {
            var requestMethod = request.Method;
            var requestPath = request.Path;

            if (!this.routes.ContainsKey(requestMethod) ||
                !this.routes[requestMethod].ContainsKey(requestPath))
            {
                return new NotFoundResponse();

            }

            return this.routes[requestMethod][requestPath];
        }
    }
}