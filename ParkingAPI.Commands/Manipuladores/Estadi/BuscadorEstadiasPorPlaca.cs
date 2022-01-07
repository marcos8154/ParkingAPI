using IoCdotNet;
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
    internal sealed class BuscadorEstadiasPorPlaca : ManipuladorComando<BuscarEstadiasPorPlaca>
    {
        private readonly IEstadiaRepository estaRepos;
        public BuscadorEstadiasPorPlaca()
        {
            estaRepos = IoC.Resolve<IEstadiaRepository>();
        }

        protected override ResultadoAcao ManipulaComando(BuscarEstadiasPorPlaca cmd)
        {
            try
            {
                cmd.Valida();

                IReadOnlyCollection<Estadia> est = estaRepos.ObterEstadiaPorPlaca(placa: cmd.placa);

                return new ResultadoAcao(est);
            }
            catch (Exception ex)
            {
                return new ResultadoAcao(ex);
            }
        }
    }
}
