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
    internal sealed class EntrarPlaca : ManipuladorComando<EntradaPlaca>
    {
        private readonly IEstacionamentoRepository estRepos;
        private readonly IPlacaRepository plaRepos;
        private readonly IEstadiaRepository estaRepos;
        public EntrarPlaca()
        {
            estRepos = IoC.Resolve<IEstacionamentoRepository>();
            plaRepos = IoC.Resolve<IPlacaRepository>();
            estaRepos = IoC.Resolve<IEstadiaRepository>();
        }

        protected override ResultadoAcao ManipulaComando(EntradaPlaca cmd)
        {
            try
            {
                cmd.Valida();

                Estacionamento est = estRepos.ObterPorCnpj(cmd.cnpj_estacionamento);

                if(est == null)
                    throw new Exception("Estacionamento não encontrado");

                Placa pla = plaRepos.Find(id: cmd.placa);

                if(pla == null) {
                    pla = new Placa(
                        id: cmd.placa
                    );

                    plaRepos.Add(pla);
                }
                
                Estadia esta = new Estadia(
                    estacionamento: est,
                    placaEntrando: pla
                );

                estaRepos.Add(esta);

                return new ResultadoAcao("Estadia aberta");
            }
            catch (Exception ex)
            {
                return new ResultadoAcao(ex);
            }
        }
    }
}
