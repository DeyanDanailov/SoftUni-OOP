
namespace Restaurant
{
    public class Dessert : Food
    {

        private double calories;

        public Dessert(string name, decimal price, double grams, double calories)
            : base(name, price, grams)
        {
            this.Calories = calories;
        }

        public virtual double Calories
        {
            get { return this.calories; }
            set { this.calories = value; }
        }
    }
}
