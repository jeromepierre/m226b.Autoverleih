using m226b.Autoverleih.Programm.Classes;
using m226b.Autoverleih.Programm.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace m226b.Autoverleih.Programm.Data
{
    public class ContractData : IData<RentContract>
    {
        public void AddData(RentContract obj, Repository repo)
        {
            repo.Contracts.Add(obj);
            repo.Save();
        }

        public void DeleteData(RentContract obj, Repository repo)
        {
            repo.Contracts.Add(obj);
            repo.Save();
        }
    }
}
