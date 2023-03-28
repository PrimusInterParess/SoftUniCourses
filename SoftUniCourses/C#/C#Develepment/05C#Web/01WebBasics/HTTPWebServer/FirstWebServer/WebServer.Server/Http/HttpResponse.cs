using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServer.Server.Http
{
    public abstract  class HttpResponse
    {
        public HttpResponse(HttpStatusCode status)
        {
            this.StatusCode = status;

            this.Headers.Add("Server", "Begins Server");
            this.Headers.Add("Date",$"{DateTime.UtcNow:R}");
        }

        public HttpStatusCode StatusCode { get; init; }

        public HttpHeaderCollection Headers { get; } = new();

        public string Content { get; set; }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine($"HTTP/1.1 {(int)this.StatusCode} {this.StatusCode}");

            foreach (var header in this.Headers)
            {
                result.AppendLine(header.ToString());
            }


            if (!string.IsNullOrEmpty(this.Content))
            {
                result.AppendLine();

                result.Append(this.Content);

            }
            

            return result.ToString();
        }
    }
}
