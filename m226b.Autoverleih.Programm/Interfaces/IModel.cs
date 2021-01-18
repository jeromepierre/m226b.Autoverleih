using System;
using System.Collections.Generic;
using System.Text;

namespace m226b.Autoverleih.Programm.Interfaces
{
    public interface IModel
    {
        Guid Id { get; }
        void PrintInfos();
    }
}
