using System.Linq;
using CollectionHierarchy.Contracts;

namespace CollectionHierarchy.Models
{
    public class AddRemoveCollection :  IAddremovable
    {
        public AddRemoveCollection()
        {
            this.Items = new string[0];
        }
        public string[] Items { get; private set; }

        public int Add(string item)
        {
            var newArr = new string[this.Items.Length + 1];
            newArr[0] = item;
            for (int i = 1; i < newArr.Length; i++)
            {
                newArr[i] = this.Items[i -1];
            }
            this.Items = newArr.ToArray();
            return 0;
        }

        public string Remove()
        {
            var result = this.Items[this.Items.Length - 1];
            var newArr = new string[this.Items.Length - 1];
            for (int i = 0; i < newArr.Length; i++)
            {
                newArr[i] = this.Items[i];
            }
            this.Items = newArr.ToArray();
            return result;
        }
    }
}
