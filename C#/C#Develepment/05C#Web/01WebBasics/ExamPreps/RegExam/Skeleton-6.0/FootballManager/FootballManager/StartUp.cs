using FootballManager.Contracts;
using FootballManager.Data;
using FootballManager.Services;

namespace FootballManager
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


            server.ServiceCollection.Add<FootballManagerDbContext>()
                .Add<IUserService,UserService>()
                .Add<IRepository,Repository>()
                .Add<IValidationService,ValidationService>()
                .Add<IPlayerService,PlayerService>();

            await server.Start();
        }
    }
}
