

namespace Cars
{
    public abstract class Car
    {
        protected Car(string model, string color)
        {
            this.Model = model;
            this.Color = color;
        }

        public string Model { get; private set; }

        public string Color { get; private set; }

        public string Start()
        {
            return "Engine Start";
        }

        public string Stop()
        {
            return "Breaaak!";
        }
    }
}
