using System;


namespace PizzaCalories.Models
{
    public class Dough
    {
        private string flourType;
        private string bakingTech;
        private double weight;
        public Dough(string flourType, string bakingTech, double weight)
        {
            this.FlourType = flourType;
            this.BakingTech = bakingTech;
            this.Weight = weight;
        }
        public string FlourType
        {
            get
            {
                return this.flourType;
            }
            set
            {
                if (!(value == "White" || value == "Wholegrain"))
                {
                    throw new ArgumentException(Common.GlobalConstants.INVALID_DOUGH_TYPE);
                }
                this.flourType = value;
            }
        }
        public string BakingTech
        {
            get
            {
                return this.bakingTech;
            }
            set
            {
                if (!(value == "Crispy" || value == "Chewy" || value == "Homemade"))
                {
                    throw new ArgumentException(Common.GlobalConstants.INVALID_DOUGH_TYPE);
                }
                this.bakingTech = value;
            }
        }
        public double Weight
        {
            get
            {
                return this.weight;
            }
            set
            {
                if (value < Common.GlobalConstants.MIN_DOUGH_WEIGHT || value > Common.GlobalConstants.MAX_DOUGH_WEIGHT)
                {
                    throw new ArgumentException(Common.GlobalConstants.INVALID_DOUGH_WEIGHT);
                }
                this.weight = value;
            }
        }
        public double GetDoughCalories(string flourType, string bakingTech, double weight)
        { 
            double calories = 2*weight;
            switch (flourType)
            {
                case "White":
                    calories *= 1.5;
                    break;
                case "Wholegrain":
                    calories *= 1.0;
                    break;
               
                default:
                    break;
            }


            return calories;
        }
    }
}
