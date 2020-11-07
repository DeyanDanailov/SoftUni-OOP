
using System.Text;

namespace Animals
{
    public class Animal
    {
        private string name;
        private string favouriteFood;
        public Animal(string name, string favouriteFood)
        {
            this.Name = name;
            this.FavoutireFood = favouriteFood;
        }
        public string Name { get; protected set; }
        public string FavoutireFood { get; protected set; }
        public virtual string ExplainSelf()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"I am {this.Name} and my fovourite food is {this.FavoutireFood}");
            return sb.ToString().TrimEnd();
        }
    }
}
