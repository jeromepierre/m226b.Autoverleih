using m226b.Autoverleih.Programm.Interfaces;
using System;

namespace m226b.Autoverleih.Programm.Classes
{
    [Serializable]
    public class Address : IModel
    {
        public Guid Id { get; }
        public string Street { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public Address()
        {
            Id = Guid.NewGuid();
        }

        public void PrintInfos()
        {
            Console.WriteLine($"Id: {Id}\n{Street}, {Zip} {City}");
        }
    }
}