using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkingAPI.Commands;
using ParkingAPI.Commands.Acoes.Estaciona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstacionamentoController : ControllerBase
    {
        [HttpPost("criar")]
        public async Task<IResultadoAcao> CriarEstacionamento(CriarEstacionamento cmd)
        {
            return await cmd.Executar();
        }

        [HttpPost("atualizar")]
        public async Task<IResultadoAcao> AtualizarEstacionamento(AtualizarEstacionamento cmd)
        {
            return await cmd.Executar();
        }

        [HttpPost("buscar")]
        public async Task<IResultadoAcao> BuscarEstacionamento(BuscarEstacionamento cmd)
        {
            return await cmd.Executar();
        }

        [HttpPost("buscar por cnpj")]
        public async Task<IResultadoAcao> BuscarEstacionamentoPorCnpj(BuscarEstacionamentoPorCnpj cmd)
        {
            return await cmd.Executar();
        }

        [HttpPost("excluir")]
        public async Task<IResultadoAcao> ExcluirEstacionamento(ExcluirEstacionamento cmd)
        {
            return await cmd.Executar();
        }
    }
}
