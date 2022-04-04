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
                IReadOnlyCollection<Estadia> est = estaRepos.Where(e => 
                    e.Estacionamento.CNPJ.Contains(cmd.CNPJEstacionamento) &&
                    e.PlacaId.Contains(cmd.PlacaVeiculo) && 
                    (cmd.ApenasEmAberto ? e.Encerrado() == false : e.Id != Guid.Empty))
                    .ToList();

                return new ResultadoAcao(est);
            }
            catch (Exception ex)
            {
                return new ResultadoAcao(ex);
            }
        }
    }
}
