using Dotz.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dotz.Interfaces
{
    public interface IExtratoRespositorio
    {
        //Task<IEnumerable<Usuario>> ObterTodos();
        Task<List<Extrato>> Obter(string email);
        Task Adicionar(Extrato extrato);
        //Task<bool> Remover(string email);
        //Task<bool> AtualizarDocumento(string email, Usuario usuario);
    }
}
