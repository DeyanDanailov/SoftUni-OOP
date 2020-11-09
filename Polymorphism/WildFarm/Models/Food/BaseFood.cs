

namespace WildFarm.Models.Food
{
    public abstract class BaseFood

    {
        public BaseFood(int quantity)
        {
                this.Quantity = quantity;
        }
        public int Quantity { get; set; }
    }
}
