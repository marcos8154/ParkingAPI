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
    internal sealed class BuscadorEstadiasPorEstacionamento : ManipuladorComando<BuscarEstadiasPorEstacionamento>
    {
        private readonly IEstadiaRepository estaRepos;
        public BuscadorEstadiasPorEstacionamento()
        {
            estaRepos = IoC.Resolve<IEstadiaRepository>();
        }

        protected override ResultadoAcao ManipulaComando(BuscarEstadiasPorEstacionamento cmd)
        {
            try
            {
                cmd.Valida();

                IReadOnlyCollection<Estadia> est = estaRepos.ObterEstadiaPorEstacionamento(cnpj_estacionamento: cmd.cnpj_estacionamento);

                return new ResultadoAcao(est);
            }
            catch (Exception ex)
            {
                return new ResultadoAcao(ex);
            }
        }
    }
}
