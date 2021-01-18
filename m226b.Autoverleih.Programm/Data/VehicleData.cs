using m226b.Autoverleih.Programm.Classes;
using m226b.Autoverleih.Programm.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace m226b.Autoverleih.Programm.Data
{
    class VehicleData : IData<Vehicle>
    {
        public void AddData(Vehicle obj, Repository repo)
        {
            repo.Vehicles.Add(obj);
        }

        public void DeleteData(Vehicle obj, Repository repo)
        {
            repo.Vehicles.Remove(obj);
        }
    }
}
