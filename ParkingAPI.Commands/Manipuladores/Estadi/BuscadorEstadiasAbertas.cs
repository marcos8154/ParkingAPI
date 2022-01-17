﻿using IoCdotNet;
using ParkingAPI.Commands.Acoes.Estadi;
using ParkingAPI.Dominio;
using ParkingAPI.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingAPI.Commands.Manipuladores.Estadi
{
    internal sealed class BuscadorEstadiasAbertas : ManipuladorComando<BuscarEstadiasAbertas>
    {
        private readonly IEstadiaRepository estaRepos;
        public BuscadorEstadiasAbertas()
        {
            estaRepos = IoC.Resolve<IEstadiaRepository>();
        }

        protected override ResultadoAcao ManipulaComando(BuscarEstadiasAbertas cmd)
        {
            try
            {
                IReadOnlyCollection<Estadia> est = estaRepos.ObterEstadiaAberta();

                return new ResultadoAcao(est);
            }
            catch (Exception ex)
            {
                return new ResultadoAcao(ex);
            }
        }
    }
}