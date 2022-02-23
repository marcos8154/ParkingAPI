using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkingAPI.Commands;
using ParkingAPI.Commands.Acoes.Usu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpPost("criar")]
        public async Task<IResultadoAcao> CriarUsuario(CriarUsuario cmd)
        {
            return await cmd.Executar();
        }

        [HttpPut("atualizar")]
        public async Task<IResultadoAcao> AtualizarUsuario(AtualizarUsuario cmd)
        {
            return await cmd.Executar();
        }

        [HttpPost("login")]
        public async Task<IResultadoAcao> LoginUsuario(LoginUsuario cmd)
        {
            return await cmd.Executar();
        }

    }
}
