using m226b.Autoverleih.Programm.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace m226b.Autoverleih.Programm.Classes
{
    [Serializable]
    public abstract class Vehicle : IModel
    {
        public Guid Id { get; }
        public string Model { get; set; }
        public string Brand { get; set; }
        public int NumberOfSeats { get; set; }
        public int HorsePower { get; set; }
        /// <summary>
        /// In rappen
        /// </summary>
        public int PricePerDay { get; set; }
        public bool IsAvailable { get; set; }
        public Condition Condition { get; set; }
        public bool IsWashed { get; set; }
        public bool HasBeenChecked { get; set; }

        public Vehicle()
        {
            Id = Guid.NewGuid();
        }

        public bool IsReadyForRent()
        {
            return IsAvailable && Condition == Condition.Good && IsWashed;
        }

        public void ToggleRent()
        {
            IsAvailable = !IsAvailable;
        }

        public override string ToString()
        {
            return $"{Brand} {Model}";
        }

        public void PrintInfos()
        {
            Console.Write($"Id: {Id}\n {this.ToString()}, Price per day: {PricePerDay}");
        }

        public void CheckCondition(Condition condition)
        {
            Condition = condition;
            HasBeenChecked = true;
            IsWashed = false;
        }

        public void RepairVehicle()
        {
            if (Condition == Condition.Good) throw new InvalidOperationException("this vehicle is already in good condition");
            if (Condition == Condition.NeedsExternalRepair) throw new InvalidOperationException("The damage can not be repaired in house");
            Condition = Condition.Good;
        }

        public void WashVehicle()
        {
            if (IsWashed) throw new InvalidOperationException("This vehicle is already washed");
            IsWashed = !IsWashed;
        }
    }
}

public enum GearType
{
    Automatic,
    Manual
}

public enum LicenseCat
{
    A,
    A1,
    B,
    B1,
    C,
    C1
}

public enum Condition
{
    Good,
    NeedsInHouseRepair,
    NeedsExternalRepair
}
