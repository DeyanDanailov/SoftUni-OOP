
using GrandPrix.Models.Tyres;
using System.Collections.Generic;

namespace GrandPrix.Factories
{
    public class TyreFactory
    {
        public ITyre Produce(List<string> cmdArgs)
        {
            var type = cmdArgs[5];
            ITyre tyre = null;
            if (type == "Ultrasoft")
            {
                var hardness = double.Parse(cmdArgs[6]);
                var grip = double.Parse(cmdArgs[7]);
                tyre = new UltrasoftTyre(hardness, grip);
            }
            else if (type == "Hard")
            {
                var hardness = double.Parse(cmdArgs[6]);
                tyre = new HardTyre(hardness);
            }
            return tyre;
        }
    }
}
