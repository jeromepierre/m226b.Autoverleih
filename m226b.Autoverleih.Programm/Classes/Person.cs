using m226b.Autoverleih.Programm.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace m226b.Autoverleih.Programm.Classes
{
    [Serializable]
    public abstract class Person : IModel
    {
        public Guid Id { get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public Address Adress { get; set; }
        public bool IsBusinessContact { get; set; }

        public Person()
        {
            Id = Guid.NewGuid();
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }

        public void PrintInfos()
        {
            Console.WriteLine($"Id: {Id}\n {this.ToString()}");
        }
    }
}

