using SharedTrip.Contracts;
using SharedTrip.Data;
using SharedTrip.Data.Common;
using SharedTrip.Services;

namespace SharedTrip
{
    using System.Threading.Tasks;

    using MyWebServer;
    using MyWebServer.Controllers;

    using Controllers;
    using MyWebServer.Results.Views;

    public class Startup
    {
        public static async Task Main()
            => await HttpServer
                .WithRoutes(routes => routes
                    .MapStaticFiles()
                    .MapControllers())
                .WithServices(services => services
                    .Add<IViewEngine, CompilationViewEngine>()
                    .Add<IUserService, UserService>()
                    .Add<IRepository,Repository>()
                    .Add<ApplicationDbContext>()
                    .Add<ITripService,TripService>())
                .Start();
    }
}
