using Dotz.Interfaces;
using Dotz.Model;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dotz.Data
{
    public class ExtratoRepositorio : IExtratoRespositorio
    {
        private readonly Contexto _context = null;

        public ExtratoRepositorio(IOptions<Configuracao> configuracao)
        {
            _context = new Contexto(configuracao);
        }

        public async Task Adicionar(Extrato extrato)
        {
            try
            {
                await _context.Extratos.InsertOneAsync(extrato);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<Extrato>> Obter(string email)
        {
            var filter = Builders<Extrato>.Filter.Eq("Email", email);

            try
            {
                return await _context.Extratos.Find(filter).ToListAsync();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
         
    }
}
