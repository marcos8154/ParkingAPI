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

        [HttpPost("criarPlacaProprietario")]
        public async Task<IResultadoAcao> CriarPlacaProprietario(CriarPlacaProprietario cmd)
        {
            return await cmd.Executar();
        }

        [HttpPut("atualizar")]
        public async Task<IResultadoAcao> AtualizarProprietario(AtualizarProprietario cmd)
        {
            return await cmd.Executar();
        }

        [HttpGet("buscar")]
        public async Task<IResultadoAcao> BuscarProprietario()
        {
            IComandoAPI cmd = new BuscarProprietario();
            return await cmd.Executar();
        }

        [HttpGet("buscarPorDocumento/{cpfCnpj}")]
        public async Task<IResultadoAcao> BuscarProprietarioPorCpfCnpj(string cpfCnpj)
        {
            IComandoAPI cmd = new BuscarProprietarioPorDoc(cpfCnpj);
            return await cmd.Executar();
        }

        [HttpGet("pesquisar/{busca}")]
        public async Task<IResultadoAcao> BuscarProprietarioPorTipo(string busca)
        {
            IComandoAPI cmd = new BuscarProprietarioPorTipo(busca);
            return await cmd.Executar();
        }

        [HttpDelete("excluir")]
        public async Task<IResultadoAcao> ExcluirProprietario(ExcluirProprietario cmd)
        {
            return await cmd.Executar();
        }
    }
}
