using Dotz.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dotz.Interfaces
{
    public interface ISaldoRespositorio
    {
        Task<Saldo> Obter(string email);        
    }
}
