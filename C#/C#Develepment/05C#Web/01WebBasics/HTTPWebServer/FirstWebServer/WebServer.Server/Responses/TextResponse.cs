using System.Text;
using WebServer.Server.Common;
using WebServer.Server.Http;

namespace WebServer.Server.Responses

{
    public class TextResponse:HttpResponse
    {
        public TextResponse(string text) 
            : this(text,"text/plain; charset=UTF-8")
        {
        }

        public TextResponse(string text, string contentType)
        :base(HttpStatusCode.OK)
        {
            Guard.AgainstNull(text);

            var contentLenght = Encoding.UTF8.GetByteCount(text).ToString();

            this.Headers.Add("Content-Type", contentType);
            this.Headers.Add("Content-Length", contentLenght);

            this.Content = text;
        }
    }
}