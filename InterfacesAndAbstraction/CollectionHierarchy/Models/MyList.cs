using System.Linq;
using CollectionHierarchy.Contracts;

namespace CollectionHierarchy.Models
{
    public class MyList : IUsed
    {
        public MyList()
        {
            this.Items = new string[0];
        }
        public int Used
        {
            get
            {
                return this.Items.Length;
            }
            
        }

        public string[] Items { get; set; }

        public int Add(string item)
        {
            var newArr = new string[this.Items.Length + 1];
            newArr[0] = item;
            for (int i = 1; i < newArr.Length; i++)
            {
                newArr[i] = this.Items[i - 1];
            }
            this.Items = newArr.ToArray();
            return 0;
        }

        public string Remove()
        {
            var result = this.Items[0];
            var newArr = new string[this.Items.Length - 1];
            for (int i = 0; i < newArr.Length; i++)
            {
                newArr[i] = this.Items[i + 1];
            }
            this.Items = newArr.ToArray();
            return result ;
        }
    }
}
