using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServer.Server.Http
{
  public  class HttpHeaderCollection
  {
      private readonly Dictionary<string, HttpHeader> headers;

            public HttpHeaderCollection()
            {
                headers = new Dictionary<string, HttpHeader>();
            }

            public void Add(HttpHeader header)
            {
                this.headers.Add(header.Name,header);
            }

            public int Count()
                => this.headers.Count;
  }
}
