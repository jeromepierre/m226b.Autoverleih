using m226b.Autoverleih.Programm.Classes;
using m226b.Autoverleih.Programm.Data;
using m226b.Autoverleih.Programm.Exceptions;
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
            Repository repo = DataUtil.GetInitialData();
            var client = repo.Clients[0];
            var employees = repo.GetAllAvailableEmployeesForRentalSale();
            client.ChooseEmployee(repo, employees[0]);

            Assert.IsTrue(employees[0].IsOccupied && client.HasChosenEmployee);
        }

        [Test]
        public void ChooseVehicleTest()
        {
            Repository repo = DataUtil.GetInitialData();
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
            Repository repo = DataUtil.GetInitialData();
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
            Repository repo = DataUtil.GetInitialData();
            var client = repo.Clients[0];
            var employees = repo.GetAllAvailableEmployeesForRentalSale();
            client.ChooseEmployee(repo, employees[0]);
            client.LeaveEmployee(repo);
            Assert.IsTrue(!client.HasChosenEmployee);
        }

        [Test]
        public void ReturnVehicleTest()
        {
            Repository repo = DataUtil.GetInitialData();
            var client = repo.Clients[0];
            var employees = repo.GetAllAvailableEmployeesForRentalSale();
            client.ChooseEmployee(repo, employees[0]);
            var vehicles = repo.GetAllAvailableLkws();
            client.ChooseVehicle(vehicles[0], repo, DateTime.Now, DateTime.Now.AddDays(1));
            var contract = repo.Contracts.Where(ct => ct.Customer == client && ct.RentedVehicle == vehicles[0]).ToList()[0];
            client.ReturnVehicle(vehicles[0], repo, Condition.NeedsInHouseRepair);
            Assert.IsTrue(vehicles[0].Condition == Condition.NeedsInHouseRepair && vehicles[0].IsAvailable);
        }

        [Test]
        public void NoOverlappingTest()
        {
            Assert.Throws(typeof(DatesOverlapException), new TestDelegate(ClientChooseTwoVehicles));
        }

        [Test]
        public void ClientMustHaveEmployee()
        {
            Assert.Throws(typeof(InvalidOperationException), new TestDelegate(ClientChooseVehicle));
        }

        private void ClientChooseTwoVehicles()
        {
            Repository repo = DataUtil.GetInitialData();
            var client = repo.Clients[0];
            var employees = repo.GetAllAvailableEmployeesForRentalSale();
            client.ChooseEmployee(repo, employees[0]);
            var vehicles = repo.GetAllAvailableLkws();
            client.ChooseVehicle(vehicles[0], repo, DateTime.Now, DateTime.Now.AddDays(2));
            client.ChooseVehicle(vehicles[0], repo, DateTime.Now.AddDays(1), DateTime.Now.AddDays(3));
            var contract = repo.Contracts.Where(ct => ct.Customer == client && ct.RentedVehicle == vehicles[0]).ToList()[0];
            client.ReturnVehicle(vehicles[0], repo, Condition.NeedsInHouseRepair);
        }

        private void ClientChooseVehicle()
        {
            Repository repo = DataUtil.GetInitialData();
            var client = repo.Clients[0];
            client.ChooseVehicle(repo.GetAllAvailableMotorcycles()[0], repo, DateTime.Now, DateTime.Now.AddDays(1));
        }
    }
}
