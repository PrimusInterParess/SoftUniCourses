using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using SUHttpServer.HTTP;
using ContentType = SUHttpServer.HTTP.ContentType;

namespace SUHttpServer.Responses
{
    public class HtmlResponse : ContentResponse
    {
        public HtmlResponse(
            string text,
            Action<Request,Response>preRenderAction =null)
            : base(
                text, 
                ContentType.Html,
                preRenderAction)
        {
        }
    }
}
