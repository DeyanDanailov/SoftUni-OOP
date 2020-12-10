

namespace GrandPrix.Models.Tyres
{
    public abstract class Tyre : ITyre
    {
        private const int INITIAL_TYRE_DEGRADATION = 100;
        public Tyre(string name, double hardness)
        {
            this.Name = name;
            this.Hardness = hardness;
        }
        public string Name { get; private set; }

        public double Hardness { get; private set; }

        public double Degradation { get; set; } = INITIAL_TYRE_DEGRADATION;
        public virtual void DegradateTyre()
        {
            this.Degradation -= this.Hardness;
        }
        public virtual bool IsTyreBlown()
        {
            if (this.Degradation<0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
