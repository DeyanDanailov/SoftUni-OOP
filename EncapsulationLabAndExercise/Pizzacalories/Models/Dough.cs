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
                value = value.ToLower();
                if (!(value == "white" || value == "wholegrain"))
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
                value = value.ToLower();
                if (!(value == "crispy" || value == "chewy" || value == "homemade"))
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
        public double Calories
        {
            get
            {
                return this.GetDoughCalories();
            }
        }
        private double GetDoughCalories()
        { 
            double calories = 2*this.Weight;
            switch (this.FlourType)
            {
                case "white":
                    calories *= 1.5;
                    break;
                case "wholegrain":
                    calories *= 1.0;
                    break;              
                default:
                    break;
            }
            switch (this.BakingTech)
            {
                case "crispy":
                    calories *= 0.9;
                    break;
                case "chewy":
                    calories *= 1.1;
                    break;
                case "homemade":
                    calories *= 1.0;
                    break;
                default:
                    break;
            }

            return calories;
        }
    }
}
