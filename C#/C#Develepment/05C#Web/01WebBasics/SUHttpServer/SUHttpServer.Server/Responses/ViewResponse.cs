using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SUHttpServer.HTTP;
using SUHttpServer.Responses;

namespace SUHttpServer.Server.Responses
{
    public class ViewResponse : ContentResponse
    {
        private const char PathSeparator = '/';

        public ViewResponse(string viewName, string controllerName)
            : base("", ContentType.Html)
        {
            if (!viewName.Contains(ViewResponse.PathSeparator))
            {
                viewName = controllerName + PathSeparator + viewName;
            }

            var viewPath = Path.GetFullPath("./Views/" + viewName.TrimStart(PathSeparator) + ".cshtml");

            var viewContent = File.ReadAllText(viewPath);

            this.Body = viewContent;
        }
    }
}
