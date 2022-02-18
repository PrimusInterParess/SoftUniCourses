using SharedTrip.Contracts;
using SharedTrip.Data;
using SharedTrip.Data.Common;
using SharedTrip.Services;

namespace SharedTrip
{
    using BasicWebServer.Server;
    using BasicWebServer.Server.Routing;
    using System.Threading.Tasks;

    public class Startup
    {
        public static async Task Main()
        {
            var server = new HttpServer(routes => routes
               .MapControllers()
               .MapStaticFiles());

            server.ServiceCollection
                .Add<IUserService, UserService>()
                .Add<IRepository, Repository>()
                .Add<IValidationService, ValidationService>()
                .Add<ApplicationDbContext>()
                .Add<ITripService,TripService>();
              

            await server.Start();
        }
    }
}
