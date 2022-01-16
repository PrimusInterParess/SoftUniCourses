using System;
using System.Collections.Generic;
using WebServer.Server.Common;
using WebServer.Server.Http;
using WebServer.Server.Responses;

namespace WebServer.Server.Routing
{
    public class RoutingTable : IRoutingTable
    {

        private readonly Dictionary<HttpMethod, Dictionary<string, Func<HttpRequest, HttpResponse>>> routes;

        public RoutingTable()
        {
            this.routes = new Dictionary<HttpMethod, Dictionary<string, Func<HttpRequest, HttpResponse>>>()
            {
                [HttpMethod.Get] = new(),
                [HttpMethod.Put] = new(),
                [HttpMethod.Post] = new(),
                [HttpMethod.Delete] = new(),
            };
        }

        public IRoutingTable Map(
            HttpMethod method,
            string path,
            HttpResponse response)
        {
            Guard.AgainstNull(response, nameof(response));

            return this.Map(method,path,request=>response);


        }

        public IRoutingTable Map(
            HttpMethod method,
            string path,
            Func<HttpRequest, HttpResponse> responseFunc)
        {

            Guard.AgainstNull(path, nameof(path));
            Guard.AgainstNull(responseFunc, nameof(responseFunc));

            this.routes[method][path] = responseFunc;

            return this;
        }


        public IRoutingTable MapGet(
            string path,
            Func<HttpRequest, HttpResponse> responseFunc)
            => Map(HttpMethod.Get, path, responseFunc);


        public IRoutingTable MapGet(string path, HttpResponse response)
            => MapGet( path,request=> response);



        public IRoutingTable MapPost(string path, Func<HttpRequest, HttpResponse> responseFunc)
            => MapPost(path, responseFunc);


        public IRoutingTable MapPost(string path, HttpResponse response)
            => MapPost( path, request=> response);


        public HttpResponse ExecureRequest(HttpRequest request)
        {
            var requestMethod = request.Method;
            var requestPath = request.Path;

            if (!this.routes.ContainsKey(requestMethod) ||
                !this.routes[requestMethod].ContainsKey(requestPath))
            {
                return new NotFoundResponse();

            }

            var responceFunction = this.routes[requestMethod][requestPath];

            return responceFunction(request);
        }
    }
}