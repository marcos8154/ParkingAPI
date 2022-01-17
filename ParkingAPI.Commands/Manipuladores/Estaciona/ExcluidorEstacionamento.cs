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
    internal sealed class ExcluidorEstacionamento : ManipuladorComando<ExcluirEstacionamento>
    {
        private readonly IEstacionamentoRepository estRepos;
        public ExcluidorEstacionamento()
        {
            estRepos = IoC.Resolve<IEstacionamentoRepository>();
        }


        protected override ResultadoAcao ManipulaComando(ExcluirEstacionamento cmd)
        {
            try
            {
                cmd.Valida();

                Estacionamento est = estRepos.ObterPorCnpj(cmd.CNPJ);

                if(est == null)
                    throw new Exception("Estacionamento não encontrado");

                estRepos.Remove(est);
                return new ResultadoAcao("Estacionamento excluído");
            }
            catch (Exception ex)
            {
                return new ResultadoAcao(ex);
            }
        }
    }
}
