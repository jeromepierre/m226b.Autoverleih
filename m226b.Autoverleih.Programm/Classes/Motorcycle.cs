using System;
using System.Collections.Generic;
using System.Text;

namespace m226b.Autoverleih.Programm.Classes
{
    [Serializable]
    public class Motorcycle : Vehicle
    {
        public BikeType Type { get; set; }

    }
}

public enum BikeType
{
    Sport,
    Lowrider,
    Touring
}
