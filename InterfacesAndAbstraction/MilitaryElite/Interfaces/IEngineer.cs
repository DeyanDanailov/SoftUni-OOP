

using System.Collections.Generic;

namespace MilitaryElite.Interfaces
{
    interface IEngineer
    {
        List<IRepair> repairs { get; }
    }
}
