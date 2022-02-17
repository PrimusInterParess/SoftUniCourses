using SMS.Contracts;
using SMS.Data;
using SMS.Data.Common;
using SMS.Services;

namespace SMS
{
    using BasicWebServer.Server;
    using BasicWebServer.Server.Routing;
    using System.Threading.Tasks;

    public class StartUp
    {
        public static async Task Main()
        {
            var server = new HttpServer(routes => routes
               .MapControllers()
               .MapStaticFiles());

            server.ServiceCollection
                .Add<IUserService, UserService>()
                .Add<SMSDbContext>()
                .Add<IRepository, Repository>()
                .Add<IValidationService,ValidationService>()
                .Add<IProductService,ProductService>();

            await server.Start();
        }
    }
}