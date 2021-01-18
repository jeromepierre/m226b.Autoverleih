using System;
using System.Collections.Generic;
using System.Text;

namespace m226b.Autoverleih.Programm.Classes
{
    [Serializable]
    public class Lkw : Vehicle
    {
        public LkwType Type { get; set; }
        /// <summary>
        /// in kg
        /// </summary>
        public int MaxWeightLoaded { get; set; }
        public bool HasTrailer { get; set; }
        /// <summary>
        /// in cm
        /// </summary>
        public int Height { get; set; }
    }
}

public enum LkwType
{
    Transporter,
    Lkw,
}
