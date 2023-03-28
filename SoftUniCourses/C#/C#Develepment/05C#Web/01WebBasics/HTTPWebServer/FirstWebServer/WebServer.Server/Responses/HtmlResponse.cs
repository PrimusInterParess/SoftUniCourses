using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServer.Server.Responses
{
  public  class HtmlResponse:ContentResponse
    {
        public HtmlResponse(string html) 
            : base(html, "text/html; charset=UTF-8")
        {
        }

    }
}
