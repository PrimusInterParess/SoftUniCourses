using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SUHttpServer.Common;
using SUHttpServer.HTTP;

namespace SUHttpServer.Responses
{
    public class ContentResponse : Response
    {
        public ContentResponse(string content, 
            string contentType,
            Action<Request,Response> preRenderAction =null)
            : base(StatusCode.OK)
        {
            Guard.AgainstNull(content);
            Guard.AgainstNull(contentType);
            this.Headers.Add(Header.ContentType, contentType);
            this.PreRenderAction = preRenderAction;
            this.Body = content;
        }

        public override string ToString()
        {
            if (this.Body != null)
            {
                var contentLength = Encoding.UTF8.GetByteCount(this.Body).ToString();
                this.Headers.Add(Header.ContentLength,contentLength);
            }

            return base.ToString();
        }
    }
}
