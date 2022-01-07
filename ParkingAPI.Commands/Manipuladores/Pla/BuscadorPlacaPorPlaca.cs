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
    internal sealed class BuscadorPlacaPorPlaca : ManipuladorComando<BuscarPlacaPorPlaca>
    {
        private readonly IPlacaRepository plaRepos;
        public BuscadorPlacaPorPlaca()
        {
            plaRepos = IoC.Resolve<IPlacaRepository>();
        }

        protected override ResultadoAcao ManipulaComando(BuscarPlacaPorPlaca cmd)
        {
            try
            {
                cmd.Valida();

                Placa pla = plaRepos.Find(id: cmd.placa);
                
                return new ResultadoAcao(pla);
            }
            catch (Exception ex)
            {
                return new ResultadoAcao(ex);
            }
        }
    }
}
