using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkingAPI.Commands;
using ParkingAPI.Commands.Acoes.Prop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProprietarioController : ControllerBase
    {
        [HttpPost("criar")]
        public async Task<IResultadoAcao> CriarProprietario(CriarProprietario cmd)
        {
            return await cmd.Executar();
        }

        [HttpPost("criar placa")]
        public async Task<IResultadoAcao> CriarPlacaProprietario(CriarPlacaProprietario cmd)
        {
            return await cmd.Executar();
        }

        [HttpPost("atualizar")]
        public async Task<IResultadoAcao> AtualizarProprietario(AtualizarProprietario cmd)
        {
            return await cmd.Executar();
        }

        [HttpPost("buscar")]
        public async Task<IResultadoAcao> BuscarProprietario(BuscarProprietario cmd)
        {
            return await cmd.Executar();
        }

        [HttpPost("buscar por cnpj ou cpf")]
        public async Task<IResultadoAcao> BuscarProprietarioPorCpfCnpj(BuscarProprietarioPorCpfCnpj cmd)
        {
            return await cmd.Executar();
        }

        [HttpPost("buscar por tipo e pesquisa")]
        public async Task<IResultadoAcao> BuscarProprietarioPorTipo(BuscarProprietarioPorTipo cmd)
        {
            return await cmd.Executar();
        }

        [HttpPost("excluir")]
        public async Task<IResultadoAcao> ExcluirProprietario(ExcluirProprietario cmd)
        {
            return await cmd.Executar();
        }
    }
}
