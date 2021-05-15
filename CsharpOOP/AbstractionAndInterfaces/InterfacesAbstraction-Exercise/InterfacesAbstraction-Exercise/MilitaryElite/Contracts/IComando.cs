using System.Collections.Generic;

namespace MilitaryElite.Contracts
{
    public interface IComando:ISpecialisedSoldier
    {
        IReadOnlyCollection<IMission> Missions { get; }

        void AddMission(IMission mission);
    }
}