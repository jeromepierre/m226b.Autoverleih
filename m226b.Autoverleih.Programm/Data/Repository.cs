using m226b.Autoverleih.Programm.Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace m226b.Autoverleih.Programm.Data
{
    public class Repository
    {
        public Collection<Vehicle> Vehicles { get; set; }
        public Collection<Employee> Employees { get; set; }
        public Collection<Client> Clients { get; set; }
        public Collection<RentContract> Contracts { get; set; }

        public List<Lkw> GetAllAvailableLkws()
        {
            return Vehicles.OfType<Lkw>().Where(lkw => lkw.IsReadyForRent()).ToList();
        }

        public List<Car> GetAllAvailableCars()
        {
            return Vehicles.OfType<Car>().Where(car => car.IsReadyForRent()).ToList();
        }

        public List<Motorcycle> GetAllAvailableMotorcycles()
        {
            return Vehicles.OfType<Motorcycle>().Where(mc => mc.IsReadyForRent()).ToList();
        }

        public List<Employee> GetAllAvailableEmployeesForRentalSale()
        {
            return Employees.Where(empl => empl.IsReadyForCustomer() && empl.Department == Department.Sales).ToList();
        }

        public bool CheckAvailablityForDates(DateTime rentStart, DateTime rentEnd, Vehicle vehicle)
        {
            var contracts = Contracts.Where(ct => ct.RentedVehicle == vehicle);
            foreach (var ct in contracts)
            {
                if ((ct.RentalDay < rentEnd && rentStart < ct.ReturnDay)) return false;
            }
            return true;
        }

        public void GetEarningsForDay()
        {
            var contracts = Contracts.Where(ct => ct.RentalDay.Day == DateTime.Now.Day).ToList();
            int count = 0;
            int money = 0;
            foreach (var ct in contracts)
            {
                count++;
                money += ct.RentedVehicle.PricePerDay;
            }
            Console.WriteLine($"Rented vehicles: {count}, Earned money: {(float)money / 100} CHF");
        }
        public void GetEarningsForLastWeek()
        {
            var contracts = Contracts.Where(ct => ct.RentalDay.Day <= DateTime.Now.AddDays(-7).Day).ToList();
            int count = 0;
            int money = 0;
            foreach (var ct in contracts)
            {
                count++;
                money += int.Parse(ct.GetPrice());
            }
            Console.WriteLine($"Rented vehicles: {count}, Earned money: {(float)money / 100} CHF");
        }

        public void GetEarningsForLastMonth()
        {
            var contracts = Contracts.Where(ct => ct.RentalDay.Month == DateTime.Now.AddMonths(-1).Month).ToList();
            int count = 0;
            int money = 0;
            foreach (var ct in contracts)
            {
                count++;
                money += int.Parse(ct.GetPrice());
            }
            Console.WriteLine($"Rented vehicles: {count}, Earned money: {(float)money / 100} CHF");
        }

        public void GetEarningsForLastYear()
        {
            var contracts = Contracts.Where(ct => ct.RentalDay.Year == DateTime.Now.AddYears(-1).Year).ToList();
            int count = 0;
            int money = 0;
            foreach (var ct in contracts)
            {
                count++;
                money += int.Parse(ct.GetPrice());
            }
            Console.WriteLine($"Rented vehicles: {count}, Earned money: {(float)money / 100} CHF");
        }

        public void Save()
        {
            DataUtil.WriteData(this);
        }
    }
}