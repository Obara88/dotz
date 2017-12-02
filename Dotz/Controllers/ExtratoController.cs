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
    public class ExtratoController : Controller
    {
        private readonly IExtratoRespositorio _extratoRepositorio;

        public ExtratoController(IExtratoRespositorio extratoRepositorio)
        {
            _extratoRepositorio = extratoRepositorio;
        }

        // POST api/extrato
        [HttpPost]
        public void Post([FromBody]Extrato extrato)
        {
            _extratoRepositorio.Adicionar(new Extrato()
            {
                Email = extrato.Email,
                CompraId = extrato.CompraId,
                Pontos = extrato.Pontos
            });
        }

        [HttpGet("{email}")]
        public async Task<List<Extrato>> Get(string email)
        {
            return await _extratoRepositorio.Obter(email);
        }
    }
}
