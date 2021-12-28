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
    internal sealed class AtualizadorEstacionamento : ManipuladorComando<AtualizarEstacionamento>
    {
        private readonly IEstacionamentoRepository estRepos;
        public AtualizadorEstacionamento()
        {
            estRepos = IoC.Resolve<IEstacionamentoRepository>();
        }


        protected override ResultadoAcao ManipulaComando(AtualizarEstacionamento cmd)
        {
            try
            {
                cmd.Valida();

                Estacionamento est = estRepos.ObterPorCnpj(cmd.CNPJ);
                est.AtualizaInfo(
                        nome: cmd.Nome,
                        tempoEstadia: cmd.TempoEstadia,
                        valorEstadia: cmd.ValorEstadia);

                estRepos.Update(est);
                return new ResultadoAcao("Estacionamento atualizado");
            }
            catch (Exception ex)
            {
                return new ResultadoAcao(ex);
            }
        }
    }
}
