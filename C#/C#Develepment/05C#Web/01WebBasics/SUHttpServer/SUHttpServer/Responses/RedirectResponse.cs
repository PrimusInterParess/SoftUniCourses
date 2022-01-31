using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SUHttpServer.HTTP;

namespace SUHttpServer.Responses
{
  public  class RedirectResponse:Response
    {
        public RedirectResponse(string location) 
            : base(StatusCode.NotFound)
        {
            this.Headers.Add(Header.Location, location);
        }
    }
}
