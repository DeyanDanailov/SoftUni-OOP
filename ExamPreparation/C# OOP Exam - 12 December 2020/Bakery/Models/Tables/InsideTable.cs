

namespace Bakery.Models.Tables
{
    public class InsideTable : Table
    {
        private const decimal INSIDE_PRICE = 2.50m;
        public InsideTable(int tableNumber, int capacity)
            : base(tableNumber, capacity, INSIDE_PRICE)
        {

        }
    }
}
