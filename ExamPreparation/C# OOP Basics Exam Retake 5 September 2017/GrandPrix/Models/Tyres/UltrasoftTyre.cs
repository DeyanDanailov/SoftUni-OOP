

namespace GrandPrix.Models.Tyres
{
    public class UltrasoftTyre : Tyre
    {
        private const string ULTRA_NAME = "Ultrasoft";
        public UltrasoftTyre(double hardness, double grip)
            : base(ULTRA_NAME, hardness)
        {
            this.Grip = grip;
        }
        public double Grip { get; private set; }
        public override void DegradateTyre()
        {
            base.DegradateTyre();
            this.Degradation -= this.Grip;
        }
        public override bool IsTyreBlown()
        {
            if (this.Degradation < 30)
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
