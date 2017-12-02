using Dotz.Interfaces;
using Dotz.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dotz.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        // POST api/usuarios
        [HttpPost]
        public void Post([FromBody]Usuario usuario)
        {
            _usuarioRepositorio.Adicionar(new Usuario() {
                Email = usuario.Email,
                Nome = usuario.Nome
            });
        }


        [HttpGet]
        public Task<IEnumerable<Usuario>> Get()
        {
            return ObterTodosUsuarios();
        }

        private async Task<IEnumerable<Usuario>> ObterTodosUsuarios()
        {
            return await _usuarioRepositorio.ObterTodos();
        }


        // GET api/notes/5
        [HttpGet("{email}")]
        public Task<Usuario> Get(string email)
        {
            return ObterUsuarioPorId(email);
        }

        private async Task<Usuario> ObterUsuarioPorId(string email)
        {
            return await _usuarioRepositorio.Obter(email) ?? new Usuario();
        }
        
        // DELETE api/usuario/23243423
        [HttpDelete("{email}")]
        public void Delete(string email)
        {
            _usuarioRepositorio.Remover(email);
        }

        // PUT api/usuario/
        [HttpPut("{email}")]
        public void Put(string email, [FromBody]Usuario usuario)
        {
            _usuarioRepositorio.AtualizarDocumento(email, usuario);
        }


    }
}
