using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Interfaces
{
    interface ICommando
    {
        HashSet<IMission>  missions {get;}
    }
}
