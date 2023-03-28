namespace FootballManager.Contracts
{
    using System;
    using System.Collections.Generic;
    using Data.Models;
    using ViewModels.Players;

    public interface IPlayerService
    {
        (bool, ICollection<string>) AddPlayer(PlayerAddFormModel model);

        IEnumerable<PlayerListViewModel> GetAllPlayers();

        bool AddPlayerToUser(string playerId, string userId);

        ICollection<Player> GetAllPlayersByUserId(string userId);
        void RemovePlayerFromCollection(string playerId,string userId);
    }
}
