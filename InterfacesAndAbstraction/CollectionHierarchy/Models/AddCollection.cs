using System.Linq;
using CollectionHierarchy.Contracts;
namespace CollectionHierarchy.Models
{
    public class AddCollection : IAddable
    {
        public AddCollection()
        {
            this.Items = new string[0];
        }
        public string[] Items { get; private set; }

        public int Add(string item)
        {
            var newArr = new string[this.Items.Length + 1] ;
            if (this.Items.Length > 0)
            {
                for (int i = 0; i < newArr.Length -1; i++)
                {
                    newArr[i] = this.Items[i];
                }
            }
            newArr[newArr.Length - 1] = item;

            this.Items = newArr.ToArray();
            return this.Items.Length - 1;
        }
    }
}
