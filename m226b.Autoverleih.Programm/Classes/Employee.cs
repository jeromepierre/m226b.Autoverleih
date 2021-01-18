using m226b.Autoverleih.Programm.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace m226b.Autoverleih.Programm.Classes
{
    [Serializable]
    public class Employee : Person
    {
        public Department Department { get; set; }
        public bool IsOccupied { get; set; }
        public bool IsWorking { get; set; }

        public bool IsReadyForCustomer()
        {
            return !IsOccupied && IsWorking;
        }

        public void WorkForClient()
        {
            if (IsReadyForCustomer()) ToggleOccupied();
            else throw (new EmployeeNotAvailableException("This employee is not at work or already occupued"));
        }

        private void ToggleOccupied()
        {
            IsOccupied = !IsOccupied;
        }
    }
}

public enum Department
{
    Sales,
    Hr,
    Repair,
    Cleaning
}
