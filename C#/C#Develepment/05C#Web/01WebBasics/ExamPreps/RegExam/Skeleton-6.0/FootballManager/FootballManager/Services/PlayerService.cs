namespace FootballManager.Services
{
    using Contracts;
    using Data.Models;
    using ViewModels.Players;
    public class PlayerService : IPlayerService
    {
        private readonly IValidationService validationService;
        private readonly IRepository repo;

        public PlayerService(IValidationService validationService,
            IRepository repo)
        {
            this.validationService = validationService;
            this.repo = repo;
        }

        public (bool, ICollection<string>) AddPlayer(PlayerAddFormModel model)
        {
            var (isValid, errors) = validationService.ValidateModel(model);

            if (isValid == false)
            {
                return (isValid, errors);
            }

            Player player = new Player()
            {
                Description = model.Description,
                FullName = model.FullName,
                ImageUrl = model.ImageUrl,
                Position = model.Position,
                Endurance = model.Endurance,
                Speed = model.Speed
            };

            try
            {
                repo.Add(player);
                repo.SaveChanges();

                isValid = true;
            }
            catch (Exception)
            {
                isValid = false;
            }

            return (isValid, errors);
        }

        public IEnumerable<PlayerListViewModel> GetAllPlayers()
        {
            var players = repo.All<Player>().Select(p => new PlayerListViewModel()
            {
                Id = p.Id,
                Description = p.Description,
                Endurance = p.Endurance,
                ImageUrl = p.ImageUrl,
                Position = p.Position,
                Speed = p.Speed,
                FullName = p.FullName
            });

            return players;
        }

        public bool AddPlayerToUser(string playerId, string userId)
        {
            var player = repo
                .All<Player>()
                .FirstOrDefault(p => p.Id == playerId);
            UserPlayer userPlayer = null;

            bool isValid = true;

            if (player != null)
            {
                var isAlreadyIn = repo
                    .All<UserPlayer>()
                    .Any(u => u.UserId == userId && u.PlayerId == playerId);

                var user = repo
                    .All<User>()
                    .FirstOrDefault(u => u.Id == userId);

                userPlayer = new UserPlayer()
                {
                    Player = player,
                    User = user,
                    PlayerId = player.Id,
                    UserId = user.Id
                };

                try
                {
                    repo.Add(userPlayer);
                    repo.SaveChanges();
                }
                catch (Exception e)
                {
                    isValid = false;
                }
            }

            return isValid;
        }

        public ICollection<Player> GetAllPlayersByUserId(string userId)
        {
           var players = repo
                .All<UserPlayer>()
                .Where(up => up.UserId == userId)
                .Select(p => p.Player).ToList();

           return players;
        }

        public void RemovePlayerFromCollection(string playerId,string userId)
        {
            var userPlayer = repo
                .All<UserPlayer>()
                .Where(up=>up.PlayerId==playerId && up.UserId==userId)
                .FirstOrDefault();

           this.repo.Remove<UserPlayer>(userPlayer);

           repo.SaveChanges();
        }
    }
}
