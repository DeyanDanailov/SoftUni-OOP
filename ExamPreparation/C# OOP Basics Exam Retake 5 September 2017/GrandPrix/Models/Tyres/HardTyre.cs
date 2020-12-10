

namespace GrandPrix.Models.Tyres
{
    public class HardTyre : Tyre
    {
        private const string HARD_NAME = "Hard";
        public HardTyre(double hardness)
            : base(HARD_NAME, hardness)
        {
        }
    }
}
