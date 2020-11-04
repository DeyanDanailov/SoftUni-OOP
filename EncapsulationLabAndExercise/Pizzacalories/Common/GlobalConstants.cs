
namespace PizzaCalories.Common
{
    public static class GlobalConstants
    {
        public const string INVALID_DOUGH_TYPE = "Invalid type of dough.";
        public const string INVALID_DOUGH_WEIGHT = "Dough weight should be in the range [1..200].";
        public const string INVALID_TOPPING_WEIGHT = "{0} weight should be in the range [1..50].";
        public const string INVALID_TOPPING_TYPE = "Cannot place {0} on top of your pizza.";
        public const string INVALID_PIZZA_NAME = "Pizza name should be between 1 and 15 symbols.";
        public const string INVALID_TOPPING_NUMBER = "Number of toppings should be in range [0..10].";
        public const double MIN_DOUGH_WEIGHT = 1.0;
        public const double MIN_TOPPING_WEIGHT = 1.0;
        public const double MAX_DOUGH_WEIGHT = 200.0;
        public const double MAX_TOPPING_WEIGHT = 50.0;
        public const int MIN_PIZZA_NAME = 1;
        public const int MAX_PIZZA_NAME = 15;
    }
}
