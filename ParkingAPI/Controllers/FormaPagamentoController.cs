using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkingAPI.Commands;
using ParkingAPI.Commands.Acoes.FormaPag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormaPagamentoController : ControllerBase
    {
        [HttpPost("criar")]
        public async Task<IResultadoAcao> Criar(CriarFormaPag criar)
        {
            return await criar.Executar();
        }

        [HttpPut("atualizar")]
        public async Task<IResultadoAcao> Atualizar(AlterarFormaPag alterar)
        {
            return await alterar.Executar();
        }

        [HttpGet("listar")]
        public async Task<IResultadoAcao> Listar([FromQuery]PesquisarFormaPag pesquisa)
        {
            return await pesquisa.Executar();
        }
    }
}
