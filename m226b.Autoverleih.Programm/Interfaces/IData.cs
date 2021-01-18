using m226b.Autoverleih.Programm.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace m226b.Autoverleih.Programm.Interfaces
{
    public interface IData<T>
    {
        void AddData(T obj, Repository repo);
        void DeleteData(T obj, Repository repo);
    }
}
