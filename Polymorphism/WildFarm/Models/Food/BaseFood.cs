

namespace WildFarm.Models.Food
{
    public abstract class BaseFood

    {
        protected BaseFood(int quantity)
        {
                this.Quantity = quantity;
        }
        public int Quantity { get; private set; }
    }
}
