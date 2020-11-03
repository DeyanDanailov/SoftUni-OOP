using System;
using System.Collections.Generic;


namespace CustomRandomList
{
    public class RandomList : List <string>
    {
        public string RandomString()
        {
            var rand = new Random();
            var randomIndex = rand.Next(0, this.Count - 1);
            var removed = this[randomIndex];
            this.RemoveAt(randomIndex);
            return removed;
        }
    }
}
