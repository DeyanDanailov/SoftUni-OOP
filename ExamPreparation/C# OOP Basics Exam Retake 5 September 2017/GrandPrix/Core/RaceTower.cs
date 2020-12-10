

using GrandPrix.Core.Contracts;
using GrandPrix.Factories;
using GrandPrix.Models.Cars;
using GrandPrix.Models.Drivers;
using GrandPrix.Models.Tyres;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GrandPrix.Core
{
    public class RaceTower : IRaceTower
    {
        private int numberOfLaps;
        private int numberOfRemainingLaps;
        private int lengthOfLap;
        private IList<IDriver> drivers;
        private IList<IDriver> notFinishedDrivers;
        private TyreFactory tyreFactory;
        private CarFactory carFactory;
        private DriverFactory driverFactory;
        private string weather;
        public RaceTower()
        {
            this.drivers = new List<IDriver>();
            this.notFinishedDrivers = new List<IDriver>();
            this.tyreFactory = new TyreFactory();
            this.carFactory = new CarFactory();
            this.driverFactory = new DriverFactory();
            this.weather = "Sunny";
        }
        public RaceTower(int numberOfLaps, int lengthOfLap)
            : this()
        {
            this.numberOfLaps = numberOfLaps;
            this.lengthOfLap = lengthOfLap;
            this.numberOfRemainingLaps = numberOfLaps;
        }
        public void ChangeWeather(List<string> commandArgs)
        {
            this.weather = commandArgs[1];
        }

        public void CompleteLaps(List<string> commandArgs)
        {
            var lapsToComplete = int.Parse(commandArgs[1]);
            if (lapsToComplete > this.numberOfRemainingLaps)
            {
                throw new InvalidOperationException($"There is no time!On lap {this.numberOfLaps - this.numberOfRemainingLaps}.");
            }
           
            for (int i = 0; i < lapsToComplete; i++)
            {
                DrivingOneLap();
                this.drivers = this.drivers.OrderByDescending(d => d.TotalTime).ToList();
                Overtaking(i + 1);                
            }
            this.drivers = this.drivers.Where(d => d.NotFinishingReason == String.Empty).ToList();
            this.numberOfRemainingLaps -= lapsToComplete;
            if (this.numberOfRemainingLaps == 0)
            {
                IDriver winner = (IDriver)this.drivers.OrderBy(d => d.TotalTime).FirstOrDefault();
                Console.WriteLine($"{winner.Name} wins the race for {winner.TotalTime:F3} seconds.");
                Environment.Exit(0);
            }
        }

        public void DriverBoxes(List<string> commandArgs)
        {
            IDriver driver = (IDriver)this.drivers.FirstOrDefault(d => d.Name == commandArgs[2]);
            driver.TotalTime += 20;
            if (commandArgs[1] == "Refuel")
            {
                Refuel(commandArgs, driver);
            }
            else if (commandArgs[1] == "ChangeTyres")
            {
                ChangeTyres(commandArgs, driver);
            }
        }

        public string GetLeaderboard()
        {
            this.drivers = this.drivers.Where(d=>d.NotFinishingReason == String.Empty).OrderBy(d => d.TotalTime).ToList();
            var sb = new StringBuilder();
            sb.AppendLine($"Lap {this.numberOfLaps - this.numberOfRemainingLaps}/{this.numberOfLaps}");
            for (int i = 0; i < this.drivers.Count; i++)
            {
                sb.AppendLine($"{i + 1} {this.drivers[i].Name} {this.drivers[i].TotalTime:F3}");               
            }
            for (int i = 0; i < this.notFinishedDrivers.Count; i++)
            {
                sb.AppendLine($"{this.drivers.Count + i + 1} {this.notFinishedDrivers[i].Name} {this.notFinishedDrivers[i].NotFinishingReason}");
            }

            return sb.ToString().Trim();
        }

        public void RegisterDriver(List<string> commandArgs)
        {
            ITyre tyre = tyreFactory.Produce(commandArgs);
            ICar car = carFactory.Produce(commandArgs, tyre);
            IDriver driver = driverFactory.Produce(commandArgs, car, this.lengthOfLap);
            if (tyre == null || car == null || driver == null)
            {
                throw new ArgumentException("Invalid arguments for registering driver");
            }
            this.drivers.Add(driver);
        }

        //public void SetTrackInfo(int lapsNumber, int trackLength)
        //{
        //    throw new System.NotImplementedException();
        //}
        private void Overtaking(int currentLap)
        {
            for (int j = 0; j < this.drivers.Count - 1; j++)
            {
                IDriver overtaker = this.drivers[j];
                IDriver toOvertake = this.drivers[j + 1];
                if (overtaker is AggressiveDriver && overtaker.Car.Tyre is UltrasoftTyre)
                {
                    if (this.weather is "Foggy")
                    {
                        overtaker.NotFinishingReason = "Crashed";
                        //this.drivers.Remove(overtaker);
                        this.notFinishedDrivers.Add(overtaker);
                    }
                    else if (overtaker.TotalTime - toOvertake.TotalTime <= 3)
                    {
                        overtaker.TotalTime -= 3;
                        toOvertake.TotalTime += 3;
                        PrintOvertaking(j, overtaker, toOvertake, currentLap);
                    }
                }
                else if (overtaker is EnduranceDriver && overtaker.Car.Tyre is HardTyre)
                {
                    if (this.weather is "Rainy")
                    {
                        overtaker.NotFinishingReason = "Crashed";
                        //this.drivers.Remove(overtaker);
                        this.notFinishedDrivers.Add(overtaker);
                    }
                    else if (overtaker.TotalTime - toOvertake.TotalTime <= 3)
                    {
                        overtaker.TotalTime -= 3;
                        toOvertake.TotalTime += 3;
                        PrintOvertaking(j, overtaker, toOvertake, currentLap);
                    }
                }
                else if (overtaker.TotalTime - toOvertake.TotalTime <= 2)
                {
                    overtaker.TotalTime -= 2;
                    toOvertake.TotalTime += 2;
                    PrintOvertaking(j, overtaker, toOvertake, currentLap);
                }
            }
        }

        private void PrintOvertaking(int j, IDriver overtaker, IDriver toOvertake, int currentLap)
        {
            Console.WriteLine($"{overtaker.Name} has overtaken " +
                                                        $"{toOvertake.Name} on lap " +
                                                        $"{ currentLap}.");
        }

        private void DrivingOneLap()
        {
            foreach (var driver in this.drivers)
            {
                if (driver.NotFinishingReason != String.Empty)
                {
                    continue;
                }
                driver.TotalTime += 60 / (this.lengthOfLap / driver.Speed);

                driver.Car.FuelAmount -= this.lengthOfLap * driver.FuelConsumptionPerKm;
                if (driver.Car.FuelAmount < 0)
                {
                    driver.NotFinishingReason = "Out of fuel";
                    this.notFinishedDrivers.Add(driver);
                }
                driver.Car.Tyre.DegradateTyre();
                if (driver.Car.Tyre.IsTyreBlown())
                {
                    driver.NotFinishingReason = "Blown Tyre";
                    this.notFinishedDrivers.Add(driver);
                }

            }
        }
        private void ChangeTyres(List<string> commandArgs, IDriver driver)
        {
            var type = commandArgs[3];
            ITyre newTyre = null;
            if (type == "Ultrasoft")
            {
                var hardness = double.Parse(commandArgs[4]);
                var grip = double.Parse(commandArgs[5]);
                newTyre = new UltrasoftTyre(hardness, grip);
            }
            else if (type == "Hard")
            {
                var hardness = double.Parse(commandArgs[4]);
                newTyre = new HardTyre(hardness);
            }
            if (driver != null)
            {
                driver.Car.Tyre = newTyre;
            }
        }

        private void Refuel(List<string> commandArgs, IDriver driver)
        {
            double fuelToRefuel = double.Parse(commandArgs[3]);
            if (driver != null)
            {
                driver.Car.FuelAmount += fuelToRefuel;
                if (driver.Car.FuelAmount > 160)
                {
                    driver.Car.FuelAmount = 160;
                }
            }
        }
    }
}
