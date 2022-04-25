using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkingAPI.Commands;
using ParkingAPI.Commands.Acoes.Cobr;
using ParkingAPI.Commands.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CobrancaController : ControllerBase
    {
        [HttpGet("{codigoCobranca}")]
        public async Task<IResultadoAcao> VerCobranca(string codigoCobranca)
        {
            return await new ConsultarCobranca(codigoCobranca).Executar();
        }

        [HttpGet("listarPorPlaca")]
        public async Task<IResultadoAcao> ListarPorPlaca([FromQuery] ListarCobrancasPorPlaca consulta)
        {
            return await consulta.Executar();
        }

        [HttpPut("pagamentoCobranca")]
        public async Task<IResultadoAcao> Pagamento([FromBody] EfetuarPagamentoCobranca cmd)
        {
            return await cmd.Executar();
        }
    }
}
