using Dotz.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dotz.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Task<IEnumerable<Usuario>> ObterTodos();
        Task<Usuario> Obter(string email);
        Task Adicionar(Usuario usuario);
        Task<bool> Remover(string email);
        Task<bool> AtualizarDocumento(string email, Usuario usuario);
    }
}
