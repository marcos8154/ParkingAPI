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

        [HttpPost("buscar")]
        public async Task<IResultadoAcao> BuscarEstadias(BuscarEstadias cmd)
        {
            return await cmd.Executar();
        }

        [HttpPost("buscar abertas")]
        public async Task<IResultadoAcao> BuscarEstadiasAbertas(BuscarEstadiasAbertas cmd)
        {
            return await cmd.Executar();
        }

        [HttpPost("buscar por estacionamento")]
        public async Task<IResultadoAcao> BuscarEstadiasPorEstacionamento(BuscarEstadiasPorEstacionamento cmd)
        {
            return await cmd.Executar();
        }

        [HttpPost("buscar por placa")]
        public async Task<IResultadoAcao> BuscarEstadiasPorPlaca(BuscarEstadiasPorPlaca cmd)
        {
            return await cmd.Executar();
        }
    }
}
