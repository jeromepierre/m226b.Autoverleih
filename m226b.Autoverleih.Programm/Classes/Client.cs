using m226b.Autoverleih.Programm.Data;
using m226b.Autoverleih.Programm.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace m226b.Autoverleih.Programm.Classes
{
    [Serializable]
    public class Client : Person
    {
        public bool IsRenting { get; set; }
        public bool HasOpenBill { get; set; }
        public bool HasChosenEmployee { get; set; }
        public LicenseCat cat { get; set; }

        public void ShowEmployees(Repository repo)
        {
            var availableEmpls = repo.GetAllAvailableEmployeesForRentalSale();
            foreach (var empl in availableEmpls)
            {
                empl.PrintInfos();
            }
        }

        public void ChooseEmployee(Repository repo, Employee empl)
        {
            try
            {
                empl.WorkForClient();
                HasChosenEmployee = true;
                repo.Save();
            }
            catch (EmployeeNotAvailableException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void LeaveEmployee(Repository repo)
        {
            if (HasChosenEmployee)
            {
                HasChosenEmployee = false;
                repo.Save();
            }
            else
                throw new InvalidOperationException("You don't have an employee to leave");
        }

        public void GetAllRentals(Repository repo)
        {
            var rentals = repo.Contracts.Where(ct => ct.Customer == this);
            foreach (var rental in rentals) rental.PrintInfos();
        }

        public void ShowVehicles(string category, Repository repo)
        {
            if (HasChosenEmployee)
            {
                switch (category)
                {
                    case "Motorcycle":
                        var cycles = repo.GetAllAvailableMotorcycles();
                        foreach (var mc in cycles)
                        {
                            mc.PrintInfos();
                        }
                        break;
                    case "Car":
                        var cars = repo.GetAllAvailableCars();
                        foreach (var car in cars)
                        {
                            car.PrintInfos();
                        }
                        break;
                    case "Lkw":
                        var lkws = repo.GetAllAvailableLkws();
                        foreach (var lkw in lkws)
                        {
                            lkw.PrintInfos();
                        }
                        break;
                    default:
                        throw (new InvalidOperationException("The category given is not avalaible"));
                }
            }
            else throw (new InvalidOperationException("The client is not with an employee"));
        }

        public void ChooseVehicle(Vehicle vehicle, Repository repo, DateTime rentStart, DateTime rentEnd)
        {
            if (HasChosenEmployee)
            {
                if (repo.CheckAvailablityForDates(rentStart, rentEnd, vehicle) && vehicle.IsReadyForRent())
                {
                    var ct = new RentContract(rentStart, rentEnd, vehicle, this);
                    new ContractData().AddData(ct, repo);
                    vehicle.ToggleRent();
                    repo.Save();
                    Console.WriteLine("Here is your Contract: ");
                    ct.PrintInfos();
                    Console.WriteLine("Here your Keys");
                }
                else throw (new DatesOverlapException("This vehicle is already reserved for this period"));
            }
            else throw (new InvalidOperationException("You have to get an employee"));
        }

        public void PayRental(RentContract rent, Repository repo, bool isCash, [Optional] int amount)
        {
            if (rent.HasBeenPayed) throw new AlreadyPayedException("This rental has already been payed");
            rent.PrintInfos();
            if (isCash)
            {
                float price = float.Parse(rent.GetPrice());
                if (amount < price)
                {
                    Console.WriteLine("You gave to less money...");
                    return;
                }
                Console.WriteLine($"Your return money: {amount - price}");
            }
            rent.PayRent();
            repo.Save();
        }

        public void ReturnVehicle(Vehicle vehicle, Repository repo, Condition cond)
        {
            if (vehicle.IsAvailable) throw new InvalidOperationException("This vehicle is already returend");
            vehicle.CheckCondition(cond);
            vehicle.ToggleRent();
            repo.Save();
        }
    }
}
