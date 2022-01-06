using System;
using System.Collections.Generic;
using WebServer.Server.Common;
using WebServer.Server.Http;
using WebServer.Server.Responses;

namespace WebServer.Server.Routing
{
    public class RoutingTable : IRoutingTable
    {

        private readonly Dictionary<HttpMethod, Dictionary<string, HttpResponse>> routes;

        public RoutingTable()
        {
            this.routes = new Dictionary<HttpMethod, Dictionary<string, HttpResponse>>()
            {
                [HttpMethod.Get] = new Dictionary<string, HttpResponse>(),
                [HttpMethod.Put] = new Dictionary<string, HttpResponse>(),
                [HttpMethod.Post] = new Dictionary<string, HttpResponse>(),
                [HttpMethod.Delete] = new Dictionary<string, HttpResponse>(),
            };
        }

        public IRoutingTable Map(string url, HttpMethod method, HttpResponse response)
        {
            return method switch
            {
                HttpMethod.Get => this.MapGet(url, response),
                _ => throw new InvalidOperationException($"Method '{method}' is not supported.")
            };
        }

        public IRoutingTable MapGet(string url, HttpResponse response)
        {
            Guard.AgainstNull(url, nameof(url));
            Guard.AgainstNull(response, nameof(response));

            this.routes[HttpMethod.Get][url] = response;

            return this;
        }

        public HttpResponse MatchRequest(HttpRequest request)
        {
            var requestMethod = request.Method;
            var requestUrl = request.Url;

            if (!this.routes.ContainsKey(requestMethod) || !this.routes[requestMethod].ContainsKey(requestUrl))
            {
                return new BadRequestResponse();

            }

            return this.routes[requestMethod][requestUrl];
        }
    }
}