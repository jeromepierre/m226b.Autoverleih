using m226b.Autoverleih.Programm.Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.IO;
using System.Text;

namespace m226b.Autoverleih.Programm.Data
{
    public static class DataUtil
    {
        public static Repository GenerateMockData()
        {
            Repository repo = new Repository();
            if (!File.Exists(@"C:\VS-Workspace\M226\Data")) DataInit();

            repo = ReadData<Repository>(@"C:\VS-Workspace\M226\Data\repository.txt");

            return repo;
        }

        public static Repository GetInitialData()
        {
            DataInit();
            return ReadData<Repository>(@"C:\VS-Workspace\M226\Data\repository.txt");
        }

        public static T ReadData<T>(string path) where T : class
        {
            try
            {
                string json = "";
                using (StreamReader reader = new StreamReader(path))
                {
                    json = reader.ReadToEnd();
                }
                return JsonConvert.DeserializeObject<T>(json, new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.Objects });
            }
            catch (JsonSerializationException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            catch (JsonException ex)
            {
                Console.WriteLine(ex.Message);
                return null;

            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        private static void DataInit()
        {
            Repository repo = new Repository();
            Collection<Vehicle> vehicles = new Collection<Vehicle>();
            Car car1 = new Car()
            {
                Brand = "Ferrari",
                Model = "Enzo",
                HorsePower = 500,
                Condition = Condition.Good,
                HasBeenChecked = true,
                IsAvailable = true,
                IsWashed = true,
                NumberOfDoors = 2,
                NumberOfSeats = 2,
                PricePerDay = 3000,
                Type = CarType.Sport
            };

            Car car2 = new Car()
            {
                Brand = "Subaru",
                Model = "Impreza",
                HorsePower = 200,
                Condition = Condition.NeedsInHouseRepair,
                HasBeenChecked = true,
                IsAvailable = true,
                IsWashed = true,
                NumberOfDoors = 5,
                NumberOfSeats = 5,
                PricePerDay = 1000,
                Type = CarType.Combi
            };

            vehicles.Add(car1);
            vehicles.Add(car2);

            Lkw lkw1 = new Lkw()
            {
                Brand = "Scavia",
                Model = "TheBigOne",
                HorsePower = 1000,
                Condition = Condition.NeedsExternalRepair,
                HasBeenChecked = true,
                IsAvailable = true,
                IsWashed = true,
                HasTrailer = true,
                Height = 300,
                MaxWeightLoaded = 20000,
                NumberOfSeats = 3,
                PricePerDay = 3000,
                Type = LkwType.Lkw
            };

            Lkw lkw2 = new Lkw()
            {
                Brand = "Mercedes",
                Model = "NotSoBigOne",
                HorsePower = 150,
                Condition = Condition.Good,
                HasBeenChecked = true,
                IsAvailable = true,
                IsWashed = true,
                HasTrailer = false,
                Height = 200,
                MaxWeightLoaded = 1000,
                NumberOfSeats = 8,
                PricePerDay = 1500
            };

            vehicles.Add(lkw1);
            vehicles.Add(lkw2);

            Motorcycle mc1 = new Motorcycle()
            {
                Brand = "Harley Davidson",
                Model = "Sportser",
                HorsePower = 100,
                Condition = Condition.Good,
                HasBeenChecked = true,
                IsAvailable = true,
                IsWashed = true,
                NumberOfSeats = 2,
                PricePerDay = 1000,
                Type = BikeType.Lowrider
            };

            Motorcycle mc2 = new Motorcycle()
            {
                Brand = "BMW",
                Model = "TourTour",
                HorsePower = 90,
                Condition = Condition.NeedsInHouseRepair,
                HasBeenChecked = true,
                IsAvailable = true,
                IsWashed = true,
                NumberOfSeats = 2,
                PricePerDay = 800,
                Type = BikeType.Touring
            };

            vehicles.Add(mc1);
            vehicles.Add(mc2);

            repo.Vehicles = vehicles;

            Collection<Employee> empls = new Collection<Employee>();
            Employee empl1 = new Employee()
            {
                FirstName = "Ursin",
                LastName = "Schleiss",
                BirthDate = new DateTime(1994, 4, 12),
                Department = Department.Sales,
                IsBusinessContact = false,
                IsOccupied = false,
                IsWorking = true,
                Adress = new Address
                {
                    Street = "Diestrasse 23",
                    City = "Aarau",
                    Zip = "7399",
                    Country = "Schweiz"
                }
            };
            Employee empl2 = new Employee()
            {
                FirstName = "Elias",
                LastName = "Gemperle",
                BirthDate = new DateTime(1994, 7, 16),
                Department = Department.Sales,
                IsBusinessContact = false,
                IsOccupied = true,
                IsWorking = true,
                Adress = new Address
                {
                    Street = "Testweg 12",
                    City = "Zug",
                    Zip = "6300",
                    Country = "Schweiz"
                }
            };
            Employee empl3 = new Employee()
            {
                FirstName = "Tim",
                LastName = "Barmettler",
                BirthDate = new DateTime(2000, 4, 12),
                Department = Department.Hr,
                IsBusinessContact = false,
                IsOccupied = false,
                IsWorking = true,
                Adress = new Address
                {
                    Street = "Derweg 2",
                    City = "Luzern",
                    Zip = "6321",
                    Country = "Schweiz"
                }
            };

            empls.Add(empl1);
            empls.Add(empl2);
            empls.Add(empl3);

            repo.Employees = empls;

            Collection<Client> clients = new Collection<Client>();
            Client cl1 = new Client()
            {
                FirstName = "Kurt",
                LastName = "Häfliger",
                BirthDate = new DateTime(1994, 1, 1),
                cat = LicenseCat.A1,
                HasOpenBill = false,
                IsBusinessContact = false,
                IsRenting = false,
                Adress = new Address()
                {
                    Street = "Strassestrasse 12",
                    City = "Bern",
                    Zip = "8008",
                    Country = "Schweiz"
                }
            };

            Client cl2 = new Client()
            {
                FirstName = "Sören",
                LastName = "Hagen",
                BirthDate = new DateTime(1994, 12, 12),
                cat = LicenseCat.A,
                HasOpenBill = false,
                IsBusinessContact = false,
                IsRenting = false,
                Adress = new Address()
                {
                    Street = "Wegweg 39",
                    City = "Altdorf",
                    Zip = "5003",
                    Country = "Schweiz"
                }
            };


            clients.Add(cl1);
            clients.Add(cl2);

            repo.Clients = clients;
            repo.Contracts = new Collection<RentContract>();
            WriteData(repo);
        }

        public static void WriteData<T>(T obj)
        {
            try
            {
                string json = JsonConvert.SerializeObject(obj, new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.Objects });
                using (StreamWriter writer = new StreamWriter(@"C:\VS-Workspace\M226\Data\repository.txt", false))
                {
                    writer.Write(json);
                }
            }
            catch (JsonSerializationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (JsonException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
