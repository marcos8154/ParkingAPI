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
        public async Task<IResultadoAcao> CriarEstacionamento(CriarPlaca cmd)
        {
            return await cmd.Executar();
        }

        [HttpPost("atualizar")]
        public async Task<IResultadoAcao> AtualizarEstacionamento(AtualizarPlaca cmd)
        {
            return await cmd.Executar();
        }

        [HttpPost("buscar")]
        public async Task<IResultadoAcao> BuscarEstacionamento(BuscarPlaca cmd)
        {
            return await cmd.Executar();
        }

        [HttpPost("buscar por placa")]
        public async Task<IResultadoAcao> BuscarEstacionamentoPorCnpj(BuscarPlacaPorPlaca cmd)
        {
            return await cmd.Executar();
        }

        [HttpPost("buscar por proprietario")]
        public async Task<IResultadoAcao> BuscarPlacaPorProprietario(BuscarPlacaPorPlaca cmd)
        {
            return await cmd.Executar();
        }

        [HttpPost("excluir")]
        public async Task<IResultadoAcao> ExcluirPlaca(ExcluirPlaca cmd)
        {
            return await cmd.Executar();
        }
    }
}
