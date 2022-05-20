using IoCdotNet;
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
    internal sealed class AtualizadorPlaca : ManipuladorComando<AtualizarPlaca>
    {
        private readonly IPlacaRepository plaRepos;
        public AtualizadorPlaca()
        {
            plaRepos = IoC.Resolve<IPlacaRepository>();
        }

        protected override ResultadoAcao ManipulaComando(AtualizarPlaca cmd)
        {
            try
            {
                cmd.Valida();

                Placa pla = plaRepos.Find(id: cmd.PlacaVeiculo);
                pla.AtualizaInfo(
                    descricaoVeiculo: cmd.DescricaoVeiculo,
                    prioritaria: cmd.PlacaPrioritaria
                );

                plaRepos.Update(pla);

                return new ResultadoAcao($"Placa '{pla.Id}' atualizada");
            }
            catch (Exception ex)
            {
                return new ResultadoAcao(ex);
            }
        }
    }
}
