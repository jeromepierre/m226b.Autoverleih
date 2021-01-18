using m226b.Autoverleih.Programm.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace m226b.Autoverleih.Programm.Classes
{
    [Serializable]
    public class RentContract : IModel
    {
        public Guid Id { get; }
        public DateTime RentalDay { get; set; }
        public DateTime ReturnDay { get; set; }
        public Vehicle RentedVehicle { get; set; }
        public Client Customer { get; set; }
        public bool HasBeenPayed { get; set; }

        public RentContract(DateTime start, DateTime end, Vehicle vehicle, Client client)
        {
            Id = Guid.NewGuid();
            RentalDay = start;
            ReturnDay = end;
            RentedVehicle = vehicle;
            Customer = client;
            HasBeenPayed = false;
        }

        public void PrintInfos()
        {
            Console.WriteLine($"Id: {Id}\nStart: {RentalDay}, End: {ReturnDay}, Costs: {GetPrice()} CHF");
        }

        public string GetPrice()
        {
            var start = RentalDay;
            var end = ReturnDay;
            int price = 0;
            while (start <= end)
            {
                price += RentedVehicle.PricePerDay;
                start = start.AddDays(1);
            }
            return ((float)price / 100).ToString();
        }

        public void PayRent()
        {
            HasBeenPayed = true;
        }
    }
}
