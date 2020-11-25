

using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Models.Races.Entities;
using EasterRaces.Repositories.Contracts;
using EasterRaces.Repositories.Entities;
using EasterRaces.Utilities.Messages;
using System;
using System.Linq;
using System.Text;

namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
        private const int MinParticipants = 3;
        private readonly CarRepository carRepository;
        private readonly DriverRepository driverRepository;
        private readonly RaceRepository raceRepository;
        public ChampionshipController()
        {
            this.carRepository = new CarRepository();
            this.driverRepository = new DriverRepository();
            this.raceRepository = new RaceRepository();
        }
        public string AddCarToDriver(string driverName, string carModel)
        {
            if (!this.driverRepository.GetAll().Any(d => d.Name == driverName))
            {
                string excMsg = string.Format(ExceptionMessages.DriverNotFound, driverName);
                throw new InvalidOperationException(excMsg);
            }
            if (!this.carRepository.GetAll().Any(c => c.Model == carModel))
            {
                string msg = string.Format(ExceptionMessages.CarNotFound, carModel);
                throw new InvalidOperationException(msg);
            }

            IDriver driver = this.driverRepository.GetAll().FirstOrDefault(d => d.Name == driverName);
            ICar car = this.carRepository.GetAll().FirstOrDefault(c => c.Model == carModel);

            driver.AddCar(car);
            string outputMsg = string.Format(OutputMessages.CarAdded, driverName, carModel);

            return outputMsg;
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            if (!this.raceRepository.GetAll().Any(r => r.Name == raceName))
            {
                string excMsg = string.Format(ExceptionMessages.RaceNotFound, raceName);
                throw new InvalidOperationException(excMsg);
            }
            if (!this.driverRepository.GetAll().Any(d => d.Name == driverName))
            {
                string msg = string.Format(ExceptionMessages.DriverNotFound, driverName);
                throw new InvalidOperationException(msg);
            }

            IRace race = this.raceRepository.GetAll().FirstOrDefault(r => r.Name == raceName);
            IDriver driver = this.driverRepository.GetAll().FirstOrDefault(d => d.Name == driverName);
            race.AddDriver(driver);

            string outputMsg = string.Format(OutputMessages.DriverAdded, driverName, raceName);

            return outputMsg;
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            if (this.carRepository.GetAll().Any(c => c.Model == model))
            {
                string excMesg = string.Format(ExceptionMessages.CarExists, model);
                throw new ArgumentException(excMesg);
            }
            ICar car = CarFactory(type, model, horsePower);
            this.carRepository.Add(car);
            string outputMsg = string.Format(OutputMessages.CarCreated, car.GetType().Name, model);

            return outputMsg;
        }

        public string CreateDriver(string driverName)
        {
            if (this.driverRepository.GetAll().Any(d=>d.Name == driverName))
            { 
                string msg = String.Format(ExceptionMessages.DriversExists, driverName);
                throw new ArgumentException(msg);
            }
            IDriver driver = new Driver(driverName);
            this.driverRepository.Add(driver);

            return String.Format(OutputMessages.DriverCreated, driver.Name);
        }

        public string CreateRace(string name, int laps)
        {
            if (this.raceRepository.GetAll().Any(r => r.Name == name))
            {
                string excMsg = string.Format(ExceptionMessages.RaceExists, name);
                throw new InvalidOperationException(excMsg);
            }

            IRace race = new Race(name, laps);
            this.raceRepository.Add(race);

            string outputMsg = string.Format(OutputMessages.RaceCreated, name);

            return outputMsg;
        }

        public string StartRace(string raceName)
        {
            if (!this.raceRepository.GetAll().Any(r => r.Name == raceName))
            {
                string msg = String.Format(ExceptionMessages.RaceNotFound, raceName);
                throw new InvalidOperationException(msg);
            }
            IRace race = this.raceRepository.GetAll().First(r => r.Name == raceName);
            if (race.Drivers.Count < MinParticipants)
            {
                string msg = String.Format(ExceptionMessages.RaceInvalid, race.Name, MinParticipants);
                throw new InvalidOperationException(msg);
            }
            var topThreeRacers = race.Drivers.ToList().OrderByDescending(d => d.Car.CalculateRacePoints(race.Laps)).Take(3).ToList();
            this.raceRepository.Remove(race);
            var sb = new StringBuilder();
            sb
                .AppendLine(String.Format(OutputMessages.DriverFirstPosition, topThreeRacers[0].Name, race.Name))
                .AppendLine(String.Format(OutputMessages.DriverSecondPosition, topThreeRacers[1].Name, race.Name))
                .AppendLine(String.Format(OutputMessages.DriverThirdPosition, topThreeRacers[2].Name, race.Name));

            return sb.ToString().Trim();
        }
        private static ICar CarFactory(string type, string model, int horsePower)
        {
            ICar car = null;
            if (type == "Muscle")
            {
                car = new MuscleCar(model, horsePower);
            }
            else if (type == "Sports")
            {
                car = new SportsCar(model, horsePower);
            }

            return car;
        }
    }
}
