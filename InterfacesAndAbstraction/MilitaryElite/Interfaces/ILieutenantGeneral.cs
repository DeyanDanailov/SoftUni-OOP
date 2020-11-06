using System;
using System.Collections.Generic;


namespace MilitaryElite.Interfaces
{
     public interface ILieutenantGeneral
    {
         HashSet<ISoldier> Privates { get; }
    }
}
