using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkingAPI.Commands;
using ParkingAPI.Commands.Acoes.Estadi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadiaController : ControllerBase
    {
        [HttpPost("entrada")]
        public async Task<IResultadoAcao> EntradaPlaca(EntradaPlaca cmd)
        {
            return await cmd.Executar();
        }

        [HttpPost("saida")]
        public async Task<IResultadoAcao> SaidaPlaca(SaidaPlaca cmd)
        {
            return await cmd.Executar();
        }

        [HttpGet("buscar")]
        public async Task<IResultadoAcao> BuscarEstadiasAbertas([FromBody] BuscarEstadias cmd)
        {
            return await cmd.Executar();
        }
    }
}
