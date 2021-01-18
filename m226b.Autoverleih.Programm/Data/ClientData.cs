using m226b.Autoverleih.Programm.Classes;
using m226b.Autoverleih.Programm.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace m226b.Autoverleih.Programm.Data
{
    public class ClientData : IData<Client>
    {
        public void AddData(Client obj, Repository repo)
        {
            repo.Clients.Add(obj);
        }

        public void DeleteData(Client obj, Repository repo)
        {
            repo.Clients.Remove(obj);
        }
    }
}
