

namespace CounterStrike.Models.Guns
{
    public class Riffle : Gun
    {
        public Riffle(string name, int bulletsCount) 
            : base(name, bulletsCount)
        {
        }

        public override int Fire()
        {
            return 10;
        }
    }
}
