using m226b.Autoverleih.Programm.Data;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace m226b.Autoverleih.Test
{
    public class ClientTest
    {

        [Test]
        public void ChooseEmployeeTest()
        {
            Repository repo = DataUtil.GenerateMockData();
            var client = repo.Clients[0];
            var employees = repo.GetAllAvailableEmployeesForRentalSale();
            client.ChooseEmployee(repo, employees[0]);

            Assert.IsTrue(employees[0].IsOccupied && client.HasChosenEmployee);
        }

        [Test]
        public void ChooseVehicleTest()
        {
            Repository repo = DataUtil.GenerateMockData();
            var client = repo.Clients[0];
            var employees = repo.GetAllAvailableEmployeesForRentalSale();
            client.ChooseEmployee(repo, employees[0]);
            var vehicles = repo.GetAllAvailableLkws();
            var contractCount = repo.Contracts.Count;
            client.ChooseVehicle(vehicles[0], repo, DateTime.Now, DateTime.Now.AddDays(1));
            Assert.IsTrue(!vehicles[0].IsAvailable && repo.Contracts.Count - 1 == contractCount);
        }

        [Test]
        public void PayRentalTest()
        {
            Repository repo = DataUtil.GenerateMockData();
            var client = repo.Clients[0];
            var employees = repo.GetAllAvailableEmployeesForRentalSale();
            client.ChooseEmployee(repo, employees[0]);
            var vehicles = repo.GetAllAvailableLkws();
            client.ChooseVehicle(vehicles[0], repo, DateTime.Now, DateTime.Now.AddDays(1));
            var contract = repo.Contracts.Where(ct => ct.Customer == client && ct.RentedVehicle == vehicles[0]).ToList()[0];
            client.PayRental(contract, repo, true, 1000000);
            Assert.That(contract.HasBeenPayed);
        }

        [Test]
        public void LeaveEmployeeTest()
        {
            Repository repo = DataUtil.GenerateMockData();
            var client = repo.Clients[0];
            var employees = repo.GetAllAvailableEmployeesForRentalSale();
            client.ChooseEmployee(repo, employees[0]);
            client.LeaveEmployee(repo);
            Assert.IsTrue(!client.HasChosenEmployee);
        }
    }
}
