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
    internal sealed class AtualizadorUsuario : ManipuladorComando<AtualizarUsuario>
    {
        private readonly IUsuarioRepository usuRepos;
        public AtualizadorUsuario()
        {
            usuRepos = IoC.Resolve<IUsuarioRepository>();
        }


        protected override ResultadoAcao ManipulaComando(AtualizarUsuario cmd)
        {
            try
            {
                cmd.Valida();

                Usuario usu = usuRepos.ObterLogin(login: cmd.Login);
                usu.AtualizaInfo(
                        nome: cmd.Nome,
                        login: cmd.Login,
                        senha: cmd.Senha);

                usuRepos.Update(usu);
                return new ResultadoAcao("Usuário atualizado");
            }
            catch (Exception ex)
            {
                return new ResultadoAcao(ex);
            }
        }
    }
}
