using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SUHttpServer.HTTP
{
    public class Request
    {
        public Method Method { get; private set; }

        public string Url { get; private set; }

        public HeaderCollection Headers { get; private set; }

        public string Body { get; set; }

        public IReadOnlyDictionary<string, string> Form { get; private set; }

        public CookieCollection Cookies { get; private set; }

        public static Request Parse(string request)
        {
            var lines = request
                .Split("\r\n");

            var startLine = lines
                .First()
                .Split(" ");

            var url = startLine[1];
            var method = ParseMethod(startLine[0]);
            var headers = ParseHeaders(lines.Skip(1));
            var cookies = ParseCookies(headers);

            var bodyLines = lines
                .Skip(headers.Count + 2)
                .ToArray();

            var body = string.Join("\n\r", bodyLines);

            var form = ParseForm(headers, body);

            return new Request()
            {
                Method = method,
                Url = url,
                Headers = headers,
                Cookies = cookies,
                Body = body,
                Form = form
            };
        }

        private static CookieCollection ParseCookies(HeaderCollection headers)
        {
            var coockieCollection = new CookieCollection();

            if (headers.Contains(Header.Cookie))
            {
                var coockieHeader = headers[Header.Cookie];

                var allCookies = coockieHeader.Split(";"); //:TODO 

                foreach (var cookieText in allCookies)
                {
                    var cookieParts = cookieText.Split('=');

                    var cookieName = cookieParts[0].Trim();
                    var cookieValue = cookieParts[1].Trim();

                    coockieCollection.Add(cookieName, cookieValue);
                }
            }

            return coockieCollection;
        }

        private static Dictionary<string, string> ParseForm(HeaderCollection headers, string body)
        {
            var formCollection = new Dictionary<string, string>();

            if (headers.Contains(Header.ContentType) &&
                headers[Header.ContentType] == ContentType.FormUrlEncoded)
            {
                var parseResult = ParseFormData(body);

                foreach (var (name, value) in parseResult)
                {
                    formCollection.Add(name, value);
                }
            }

            return formCollection;
        }

        private static Dictionary<string, string> ParseFormData(string bodyLines)
            => HttpUtility.UrlDecode(bodyLines)
                .Split('&')
                .Select(part => part.Split('='))
                .Where(part => part.Length == 2)
                .ToDictionary(part => part[0],
                    part => part[1], StringComparer.InvariantCultureIgnoreCase);

        private static HeaderCollection ParseHeaders(IEnumerable<string> headerLines)
        {
            var headerCollection = new HeaderCollection();

            foreach (var headerLine in headerLines)
            {
                if (headerLine == string.Empty)
                {
                    break;
                }

                var headerParts = headerLine.Split(":", 2);

                if (headerParts.Length != 2)
                {
                    throw new InvalidOperationException("Request is not valid.");
                }

                var headerName = headerParts[0];
                var headerValue = headerParts[1].Trim();

                headerCollection.Add(headerName, headerValue);
            }

            return headerCollection;
        }

        private static Method ParseMethod(string method)
        {
            try
            {
                return (Method)Enum.Parse(typeof(Method), method, true);
            }
            catch (Exception)
            {
                throw new InvalidOperationException($"Method '{method} is not supported'");
            }

        }
    }


}
