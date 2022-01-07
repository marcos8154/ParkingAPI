﻿using IoCdotNet;
using ParkingAPI.Commands.Acoes.Pla;
using ParkingAPI.Dominio;
using ParkingAPI.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingAPI.Commands.Manipuladores.Pla
{
    internal sealed class BuscadorPlaca : ManipuladorComando<BuscarPlaca>
    {
        private readonly IPlacaRepository plaRepos;
        public BuscadorPlaca()
        {
            plaRepos = IoC.Resolve<IPlacaRepository>();
        }

        protected override ResultadoAcao ManipulaComando(BuscarPlaca cmd)
        {
            try
            {
                cmd.Valida();

                IReadOnlyCollection<Placa> pla = plaRepos.FindAll();
                return new ResultadoAcao(pla);
            }
            catch (Exception ex)
            {
                return new ResultadoAcao(ex);
            }
        }
    }
}
