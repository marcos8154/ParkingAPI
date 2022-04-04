using IoCdotNet;
using ParkingAPI.Commands.Acoes.Usu;
using ParkingAPI.Commands.ViewModels;
using ParkingAPI.Dominio;
using ParkingAPI.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingAPI.Commands.Manipuladores.Usu
{
    internal sealed class LogarUsuario : ManipuladorComando<LoginUsuario>
    {
        private readonly IUsuarioRepository usuarioRepos;
        public LogarUsuario()
        {
            usuarioRepos = IoC.Resolve<IUsuarioRepository>();
        }

        public static string CalculaHash(string Senha)
        {
            try
            {
                System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(Senha);
                byte[] hash = md5.ComputeHash(inputBytes);
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                for (int i = 0; i < hash.Length; i++)
                {
                    sb.Append(hash[i].ToString("X2"));
                }
                return sb.ToString();
            }
            catch (Exception)
            {
                return null;
            }
        }

        protected override ResultadoAcao ManipulaComando(LoginUsuario cmd)
        {
            try
            {
                cmd.Valida();

                Usuario usu = usuarioRepos.Login(cmd.Login, CalculaHash(cmd.Senha));

                if (usu == null)
                    return new ResultadoAcao("Login e/ou senha incorretos.", StatusRetorno.NotFound);

                LoginViewModel res = new LoginViewModel(usu.Login,
                    token: "IMPLEMENTAR JWT!!!");

                return new ResultadoAcao(res);
            }
            catch (Exception ex)
            {
                return new ResultadoAcao(ex);
            }
        }
    }
}
