using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SUHttpServer.Common;
using SUHttpServer.HTTP;
using SUHttpServer.Responses;

namespace SUHttpServer.Routing
{
    public class RoutingTable : IRoutingTable
    {
        private readonly Dictionary<Method, Dictionary<string, Func<Request, Response>>> routes;

        public RoutingTable() =>
            this.routes = new Dictionary<Method, Dictionary<string, Func<Request, Response>>>()
            {
                [Method.Get] = new(StringComparer.InvariantCultureIgnoreCase),
                [Method.Post] = new(StringComparer.InvariantCultureIgnoreCase),
                [Method.Put] = new(StringComparer.InvariantCultureIgnoreCase),
                [Method.Delete] = new(StringComparer.InvariantCultureIgnoreCase),
            };


        public IRoutingTable Map(
            Method method,
            string path,
            Func<Request, Response> responseFunction)
        {
            Guard.AgainstNull(path, nameof(path));
            Guard.AgainstNull(responseFunction, nameof(responseFunction));

            this.routes[method][path] = responseFunction;

            return this;
        }

        public IRoutingTable MapGet(
            string path,
            Func<Request, Response> responseFunction)
            => this.Map(Method.Get, path, responseFunction);

        public IRoutingTable MapPost(string path, Func<Request, Response> responseFunction)
            => this.Map(Method.Post, path, responseFunction);

        public Response MatchRequest(Request request)
        {
            var requestMethod = request.Method;
            var requestUrl = request.Url;

            if (!this.routes.ContainsKey(requestMethod) ||
                !this.routes[requestMethod].ContainsKey(requestUrl))
            {
                return new NotFoundResponse();
            }

            var responseFunction = this.routes[requestMethod][requestUrl];

            return responseFunction(request);
        }
    }
}
