using System.Collections.Generic;

namespace MilitaryElite.Contracts
{
    public interface ILieutenantGeneral : IPrivate
    {
        IReadOnlyCollection<IPrivate> Privates { get;}

        void AddPrivate(ISoldier @private);
    }
}
