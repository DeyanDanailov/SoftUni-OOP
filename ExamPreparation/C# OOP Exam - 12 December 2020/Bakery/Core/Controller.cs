using Bakery.Core.Contracts;
using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Core
{
    public class Controller : IController
    {
        private readonly List<IBakedFood> bakedFoods;
        private readonly List<IDrink> drinks;
        private List<ITable> tables;
        private decimal totalIncome;
        public Controller()
        {
            this.bakedFoods = new List<IBakedFood>();
            this.drinks = new List<IDrink>();
            this.tables = new List<ITable>();
        }
        public string AddDrink(string type, string name, int portion, string brand)
        {
            IDrink drink = null;
            if (type == "Tea")
            {
                drink = new Tea(name, portion, brand);
            }
            else if (type == "Water")
            {
                drink = new Water(name, portion, brand);
            }
            if (drink != null)
            {
                this.drinks.Add(drink);
                return $"Added {drink.Name} ({drink.Brand}) to the drink menu";
            }
            else
            {
                return String.Empty;
            }
           
        }

        public string AddFood(string type, string name, decimal price)
        {
            IBakedFood food = null;
            if (type == "Bread")
            {
                food = new Bread(name, price);
            }
            else if (type == "Cake")
            {
                food = new Cake(name, price);
            }
            if (food != null)
            {
                this.bakedFoods.Add(food);
                return $"Added {food.Name} ({food.GetType().Name}) to the menu";
            }
            else
            {
                return String.Empty;
            }
           
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            ITable table = null;
            if (type == "InsideTable")
            {
                table = new InsideTable(tableNumber, capacity);
            }
            else if (type == "OutsideTable")
            {
                table = new OutsideTable(tableNumber, capacity);
            }
            if (table != null)
            {
                this.tables.Add(table);
                return $"Added table number {table.TableNumber} in the bakery";
            }
            else
            {
                return String.Empty;
            }
        }

        public string GetFreeTablesInfo()
        {
            var sb = new StringBuilder();

            var freeTables = this.tables.Where(t=>t.IsReserved == false).ToList();
            foreach (var table in freeTables)
            {
                sb.AppendLine(table.GetFreeTableInfo());
            }

            return sb.ToString().Trim();
        }

        public string GetTotalIncome()
        {
            return $"Total income: {this.totalIncome:f2}lv";
        }

        public string LeaveTable(int tableNumber)
        {
            ITable tableToLeave = this.tables.FirstOrDefault(t => t.TableNumber == tableNumber);

            var sb = new StringBuilder();
            sb.AppendLine($"Table: {tableToLeave.TableNumber}");
            sb.AppendLine($"Bill: {tableToLeave.GetBill():f2}");

            this.totalIncome += tableToLeave.GetBill();
            tableToLeave.Clear();

            return sb.ToString().Trim();
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            ITable table = this.tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            if (table == null)
            {
                return String.Format(OutputMessages.WrongTableNumber, tableNumber);
            }
            IDrink drink = this.drinks.FirstOrDefault(d => d.Name == drinkName && d.Brand == drinkBrand);
            if (drink == null)
            {
                return String.Format(OutputMessages.NonExistentDrink, drinkName, drinkBrand);
            }

            table.OrderDrink(drink);
            return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            ITable table = this.tables.FirstOrDefault(t=>t.TableNumber == tableNumber);
            if (table == null)
            {
                return String.Format(OutputMessages.WrongTableNumber, tableNumber);
            }
            IBakedFood food = this.bakedFoods.FirstOrDefault(f => f.Name == foodName);
            if (food == null)
            {
                return String.Format(OutputMessages.NonExistentFood, foodName);
            }
            table.OrderFood(food);
            return String.Format(OutputMessages.FoodOrderSuccessful, tableNumber, foodName);
        }

        public string ReserveTable(int numberOfPeople)
        {
            ITable freeTable = this.tables.Where(t => t.IsReserved == false)
                                          .Where(t => t.Capacity >= numberOfPeople)
                                          .FirstOrDefault();
            if (freeTable == null)
            {
                return String.Format(OutputMessages.ReservationNotPossible, numberOfPeople);
            }
            else
            {
                freeTable.Reserve(numberOfPeople);
                return String.Format(OutputMessages.TableReserved, freeTable.TableNumber, numberOfPeople);
            }
        }
    }
}
