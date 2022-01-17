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
    internal sealed class BuscadorEstacionamentoPorCnpj : ManipuladorComando<BuscarEstacionamentoPorCnpj>
    {
        private readonly IEstacionamentoRepository estRepos;
        public BuscadorEstacionamentoPorCnpj()
        {
            estRepos = IoC.Resolve<IEstacionamentoRepository>();
        }


        protected override ResultadoAcao ManipulaComando(BuscarEstacionamentoPorCnpj cmd)
        {
            try
            {
                cmd.Valida();

                Estacionamento est = estRepos.ObterPorCnpj(cmd.CNPJ);
                
                return new ResultadoAcao(est);
            }
            catch (Exception ex)
            {
                return new ResultadoAcao(ex);
            }
        }
    }
}
