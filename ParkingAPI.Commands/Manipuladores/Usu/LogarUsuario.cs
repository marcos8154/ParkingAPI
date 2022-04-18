﻿using IoCdotNet;
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

        protected override ResultadoAcao ManipulaComando(LoginUsuario cmd)
        {
            try
            {
                cmd.Valida();

                Usuario usu = usuarioRepos.Login(cmd.Login, cmd.Senha);

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
