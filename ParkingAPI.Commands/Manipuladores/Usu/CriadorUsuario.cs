using IoCdotNet;
using ParkingAPI.Commands.Acoes.Usu;
using ParkingAPI.Dominio;
using ParkingAPI.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingAPI.Commands.Manipuladores.Usu
{
    internal sealed class CriadorUsuario : ManipuladorComando<CriarUsuario>
    {
        private readonly IUsuarioRepository usuarioRepos;
        public CriadorUsuario()
        {
            usuarioRepos = IoC.Resolve<IUsuarioRepository>();
        }

        protected override ResultadoAcao ManipulaComando(CriarUsuario cmd)
        {
            try
            {
                cmd.Valida();

                Usuario est = new Usuario(
                           nome: cmd.Nome,
                           login: cmd.Login,
                           senha: cmd.Senha);

                usuarioRepos.Add(est);

                return new ResultadoAcao("Usuário criado");
            }
            catch (Exception ex)
            {
                return new ResultadoAcao(ex);
            }
        }
    }
}
