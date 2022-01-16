using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace WebServer.Server.Http
{
    public class HttpRequest
    {
        private const string NewLine = "\r\n";

        public HttpMethod Method { get; private set; }

        public string Path { get; private set; }

        public HttpHeaderCollection Headers { get; private set; }

        public string Body { get; set; }

        public Dictionary<string, string> Query { get; private set; }


        public static HttpRequest Parse(string request)
        {
            var lines = request.Split(NewLine);

            var startLine = lines.First().Split(" ");

            var method = ParseHttpMethod(startLine[0]);
            var url = startLine[1];

            var (path, query) = ParseUrl(url);

            var headerLines = lines.Skip(1);

            var headerCollection = ParseHeaderCollection(headerLines);

            var bodyLines = lines.Skip(headerCollection.Count() + 2).ToArray();

            var body = string.Join(NewLine, bodyLines);

            return new HttpRequest()
            {
                Method = method,
                Path = path,
                Headers = headerCollection,
                Query = query,
                Body = body
            };
        }


        private static HttpMethod ParseHttpMethod(string method)
        {
            return method.ToUpper() switch
            {
                "GET" => HttpMethod.Get,
                "DELETE" => HttpMethod.Delete,
                "POST" => HttpMethod.Post,
                "PUT" => HttpMethod.Put,
                _ => throw new InvalidOperationException($"Method {method} is not supported.")
            };
        }

        private static (string, Dictionary<string, string>) ParseUrl(string url)
        {
            var urlParts = url.Split("?",2);

            var path = urlParts[0];
            var query = ParseQuery(urlParts);

            return (path, query);
        }

        private static Dictionary<string, string> ParseQuery(string[] queryString)
        {
            var query = new Dictionary<string, string>();

            if (queryString.Length > 1)
            {
                query = queryString[1]
                    .Split('&')
                    .Select(part => part.Split('='))
                    .Where(part => part.Length == 2)
                    .ToDictionary(p => p[0], p => p[1]);
            }

            return query;
        }

        private static HttpHeaderCollection ParseHeaderCollection(IEnumerable<string> headerLines)
        {
            var headerCollection = new HttpHeaderCollection();

            foreach (var headerLine in headerLines)
            {
                if (headerLine == String.Empty)
                {
                    break;
                }

                var indexOfcolon = headerLine.IndexOf(":");

                if (indexOfcolon < 0)
                {
                    throw new InvalidOperationException("Request is not valid");
                }

                var headerName = headerLine.Substring(0, indexOfcolon);
                var headerValue = headerLine.Substring(indexOfcolon + 1).Trim();

                headerCollection.Add(headerName, headerValue);
            }

            return headerCollection;
        }

        //private static string GetStartLine(string request)
        //{


        //}
    }
}
