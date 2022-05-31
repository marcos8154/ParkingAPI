using IoCdotNet;
using ParkingAPI.Commands.Acoes.Estadi;
using ParkingAPI.Commands.ViewModels;
using ParkingAPI.Dominio;
using ParkingAPI.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingAPI.Commands.Manipuladores.Estadi
{
    internal sealed class BuscadorEstadias : ManipuladorComando<BuscarEstadias>
    {
        private readonly IEstadiaRepository estaRepos;
        public BuscadorEstadias()
        {
            estaRepos = IoC.Resolve<IEstadiaRepository>();
        }

        protected override ResultadoAcao ManipulaComando(BuscarEstadias cmd)
        {
            try
            {
                List<Estadia> est = estaRepos.BuscarEstadias(cmd.CNPJEstacionamento,
                    cmd.PlacaVeiculo, cmd.ApenasEmAberto);

                List<EstadiaViewModel> vms = new List<EstadiaViewModel>();
                est.ForEach(e => vms.Add(new EstadiaViewModel(e)));

                return new ResultadoAcao($"{vms.Count} estadia{(vms.Count > 1 ? "s" : "")} encontradas", vms);
            }
            catch (Exception ex)
            {
                return new ResultadoAcao(ex);
            }
        }
    }
}
