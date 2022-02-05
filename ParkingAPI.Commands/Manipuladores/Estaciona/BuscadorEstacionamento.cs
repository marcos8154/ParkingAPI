using IoCdotNet;
using ParkingAPI.Commands.Acoes.Estaciona;
using ParkingAPI.Dominio;
using ParkingAPI.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingAPI.Commands.Manipuladores.Estaciona
{
    internal sealed class BuscadorEstacionamento : ManipuladorComando<BuscarEstacionamento>
    {
        private readonly IEstacionamentoRepository estRepos;
        public BuscadorEstacionamento()
        {
            estRepos = IoC.Resolve<IEstacionamentoRepository>();
        }


        protected override ResultadoAcao ManipulaComando(BuscarEstacionamento cmd)
        {
            try
            {
                var est = estRepos.Todos();
                return new ResultadoAcao(est);
            }
            catch (Exception ex)
            {
                return new ResultadoAcao(ex);
            }
        }
    }
}
