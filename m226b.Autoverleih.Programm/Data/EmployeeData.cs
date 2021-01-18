using m226b.Autoverleih.Programm.Classes;
using m226b.Autoverleih.Programm.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace m226b.Autoverleih.Programm.Data
{
    public class EmployeeData : IData<Employee>
    {
        public void AddData(Employee obj, Repository repo)
        {
            repo.Employees.Add(obj);
        }

        public void DeleteData(Employee obj, Repository repo)
        {
            repo.Employees.Remove(obj);
        }
    }
}
