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

        public string Url { get; private set; }

        public HttpHeaderCollection Headers { get; private set; }

        public string Body { get; set; }


        public static HttpRequest Parse(string request)
        {
            var lines = request.Split(NewLine);

            var startLine = lines.First().Split(" ");

            var method = ParseHttpMethod(startLine[0]);
            var url = startLine[1];
            var headerLines = lines.Skip(1);

            var headerCollection = ParseHeaderCollection(headerLines);

            var bodyLines = lines.Skip(headerCollection.Count() + 2).ToArray();

            var body = string.Join(NewLine, bodyLines);

            return new HttpRequest()
            {
                Method = method,
                Url = url,
                Headers = headerCollection,
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
                var header = new HttpHeader()
                {
                    Name = headerLine.Substring(0,indexOfcolon),
                    Value = headerLine.Substring(indexOfcolon+1).Trim()

                };

                headerCollection.Add(header);

            }

            return headerCollection;
        }

        //private static string GetStartLine(string request)
        //{


        //}
    }
}
