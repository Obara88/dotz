using Dotz.Interfaces;
using Dotz.Model;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Dotz.Data
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly Contexto _context = null;

        public UsuarioRepositorio(IOptions<Configuracao> configuracao)
        {
            _context = new Contexto(configuracao);
        }

        public async Task Adicionar(Usuario usuario)
        {
            try
            {
                await _context.Usuarios.InsertOneAsync(usuario);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public async Task<IEnumerable<Usuario>> ObterTodos()
        {
            try
            {
                return await _context.Usuarios.Find(_ => true).ToListAsync();
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public async Task<Usuario> Obter(string email)
        {
            var filter = Builders<Usuario>.Filter.Eq("Email", email);

            try
            {
                return await _context.Usuarios.Find(filter).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }



        public async Task<bool> Remover(string email)
        {
            try
            {
                DeleteResult actionResult = await _context.Usuarios.DeleteOneAsync(Builders<Usuario>.Filter.Eq("Email", email));

                return actionResult.IsAcknowledged && actionResult.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        

        public async Task<bool> AtualizarDocumento(string email, Usuario usuario)
        {
            var usuarioUpdate = await Obter(email) ?? new Usuario();
            usuarioUpdate.Email = usuario.Email;
            usuarioUpdate.Nome = usuario.Nome;

            return await AtualizarUsuario(email, usuario);
        }

        public async Task<bool> AtualizarUsuario(string email, Usuario Usuario)
        {
            try
            {
                ReplaceOneResult actionResult = await _context.Usuarios
                                                .ReplaceOneAsync(n => n.Email.Equals(email)
                                                                , Usuario
                                                                , new UpdateOptions { IsUpsert = true });
                return actionResult.IsAcknowledged && actionResult.ModifiedCount > 0;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
    }
}
