using Dotz.Interfaces;
using Dotz.Model;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dotz.Data
{
    public class SaldoRespositorio : ISaldoRespositorio
    {
        private readonly Contexto _context = null;
        private readonly IExtratoRespositorio _extratoRepositorio;

        public SaldoRespositorio(IOptions<Configuracao> configuracao, IExtratoRespositorio extratoRepositorio)
        {
            _context = new Contexto(configuracao);
            _extratoRepositorio = extratoRepositorio;
        }

        public async Task<Saldo> Obter(string email)
        {
            try
            {
                List<Extrato> extrato = await _extratoRepositorio.Obter(email);

                var somaTotalPontos = extrato.Sum(_ => _.Pontos);
                return new Saldo() { Email = email, Pontos = somaTotalPontos };

            }
            catch (Exception ex)
            {
                throw;
            }











            throw new NotImplementedException();
        }
    }
}
