using m226b.Autoverleih.Programm.Data;
using m226b.Autoverleih.Programm.Exceptions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace m226b.Autoverleih.Test
{
    public class EmployeeTest
    {
        [Test]
        public void EmployeeMustBeFreeTeset()
        {
            Assert.Throws(typeof(EmployeeNotAvailableException), new TestDelegate(ChooseOccupiedEmployee));
        }

        private void ChooseOccupiedEmployee()
        {
            Repository repo = DataUtil.GetInitialData();
            var client1 = repo.Clients[0];
            var employees = repo.GetAllAvailableEmployeesForRentalSale();
            client1.ChooseEmployee(repo, employees[0]);
            employees[0].WorkForClient();
        }
    }
}
