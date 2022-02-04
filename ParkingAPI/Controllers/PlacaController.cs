using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkingAPI.Commands;
using ParkingAPI.Commands.Acoes.Pla;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlacaController : ControllerBase
    {
        [HttpPost("criar")]
        public async Task<IResultadoAcao> CriarPlaca(CriarPlaca cmd)
        {
            return await cmd.Executar();
        }

        [HttpPut("atualizar")]
        public async Task<IResultadoAcao> AtualizarPlaca(AtualizarPlaca cmd)
        {
            return await cmd.Executar();
        }

        [HttpGet("obter/{placaVeiculo}")]
        public async Task<IResultadoAcao> BuscarPlaca(string placaVeiculo)
        {
            IComandoAPI cmd = new BuscarPlaca(placaVeiculo);
            return await cmd.Executar();
        }

        [HttpGet("placasPorProprietario/{cpfCnpjProprietario}")]
        public async Task<IResultadoAcao> BuscarPlacaPorProprietario(string cpfCnpjProprietario)
        {
            IComandoAPI cmd = new ListarPlacasDoProprietario(cpfCnpjProprietario);
            return await cmd.Executar();
        }

        [HttpDelete("excluir/{placaVeiculo}")]
        public async Task<IResultadoAcao> ExcluirPlaca(string placaVeiculo)
        {
            IComandoAPI cmd = new ExcluirPlaca(placaVeiculo);
            return await cmd.Executar();
        }
    }
}
