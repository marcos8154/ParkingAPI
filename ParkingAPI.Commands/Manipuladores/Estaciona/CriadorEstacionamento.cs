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
    internal sealed class CriadorEstacionamento : ManipuladorComando<CriarEstacionamento>
    {
        private readonly IEstacionamentoRepository estacionamentoRepos;
        public CriadorEstacionamento()
        {
            estacionamentoRepos = IoC.Resolve<IEstacionamentoRepository>();
        }

        protected override ResultadoAcao ManipulaComando(CriarEstacionamento cmd)
        {
            try
            {
                cmd.Valida();

                Estacionamento est = new Estacionamento(
                           nome: cmd.Nome,
                           cnpj: cmd.CNPJ,
                           tempoestadia: cmd.TempoEstadia,
                           valorestadia : cmd.ValorEstadia);

                estacionamentoRepos.Add(est);

                return new ResultadoAcao("Estacionamento criado");
            }
            catch (Exception ex)
            {
                return new ResultadoAcao(ex);
            }
        }
    }
}
