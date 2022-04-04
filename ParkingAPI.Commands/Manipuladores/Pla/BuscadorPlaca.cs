using IoCdotNet;
using ParkingAPI.Commands.Acoes.Pla;
using ParkingAPI.Commands.ViewModels;
using ParkingAPI.Dominio;
using ParkingAPI.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingAPI.Commands.Manipuladores.Pla
{
    internal sealed class BuscadorPlaca : ManipuladorComando<BuscarPlaca>
    {
        private readonly IPlacaRepository plaRepos;
        public BuscadorPlaca()
        {
            plaRepos = IoC.Resolve<IPlacaRepository>();
        }

        protected override ResultadoAcao ManipulaComando(BuscarPlaca cmd)
        {
            try
            {
                cmd.Valida();

                Placa placa = plaRepos.Find(cmd.PlacaVeiculo);
                string nomeProprietario = (placa.Proprietario == null ? "PROPRIETÁRIO NÃO VINCULADO" : placa.Proprietario.Nome);
                PlacaViewModel vm = new PlacaViewModel(
                        proprietario: nomeProprietario,
                        placa: placa.Id,
                        veiculo: placa.DescricaoVeiculo,
                        prioritaria: placa.PlacaPrioritaria
                    );

                return new ResultadoAcao(vm);
            }
            catch (Exception ex)
            {
                return new ResultadoAcao(ex);
            }
        }
    }
}
