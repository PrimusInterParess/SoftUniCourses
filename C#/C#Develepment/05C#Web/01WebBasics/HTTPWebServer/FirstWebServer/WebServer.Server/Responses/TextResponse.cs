using System.Text;
using WebServer.Server.Common;
using WebServer.Server.Http;

namespace WebServer.Server.Responses

{
    public class TextResponse:ContentResponse
    {
        public TextResponse(string html) 
            : base(html,"text/plain; charset=UTF-8")
        {
        }

    
    }
}