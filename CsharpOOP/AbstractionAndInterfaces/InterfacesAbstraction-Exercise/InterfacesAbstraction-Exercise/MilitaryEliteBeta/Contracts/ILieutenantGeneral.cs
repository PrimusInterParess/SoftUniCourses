using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Contracts
{
   public interface ILieutenantGeneral:IPrivate
    {
        IReadOnlyCollection<ISoldier> Privates { get; }

        void AddPrivate(ISoldier @private);
    }
}
