using System;
using System.Collections.Generic;
using System.Text;

namespace m226b.Autoverleih.Programm.Classes
{
    [Serializable]
    public class Car : Vehicle
    {
        public CarType Type { get; set; }
        public int NumberOfDoors { get; set; }
    }
}

public enum CarType
{
    Sport,
    Suv,
    Limousine,
    Combi
}