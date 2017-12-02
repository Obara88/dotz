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
    public class SaldoController : Controller
    {
        private readonly ISaldoRespositorio _saldoRespositorio;

        public SaldoController(ISaldoRespositorio saldoRespositorio)
        {
            _saldoRespositorio = saldoRespositorio;
        }

        [HttpGet("{email}")]
        public async Task<Saldo> Get(string email)
        {
            return await _saldoRespositorio.Obter(email);
        }

        
        [HttpGet("")]
        public string Get()
        {
            return "ping";
        }

    }
}
