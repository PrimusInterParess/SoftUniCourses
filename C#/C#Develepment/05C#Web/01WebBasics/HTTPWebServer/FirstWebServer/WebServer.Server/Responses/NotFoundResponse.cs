using WebServer.Server.Http;

namespace WebServer.Server.Responses
{
    public class NotFoundResponse :HttpResponse
    {
        public NotFoundResponse() 
            : base(HttpStatusCode.NotFound)
        {
        }
    }
}