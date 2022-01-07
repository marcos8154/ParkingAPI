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
    internal sealed class BuscadorPlacaPorProprietario : ManipuladorComando<BuscarPlacaPorProprietario>
    {
        private readonly IPlacaRepository plaRepos;
        public BuscadorPlacaPorProprietario()
        {
            plaRepos = IoC.Resolve<IPlacaRepository>();
        }

        protected override ResultadoAcao ManipulaComando(BuscarPlacaPorProprietario cmd)
        {
            try
            {
                cmd.Valida();

                IReadOnlyCollection<Placa> pla = plaRepos.ObterPorProprietario(cpfCnpj: cmd.cpfCnpj);
                
                return new ResultadoAcao(pla);
            }
            catch (Exception ex)
            {
                return new ResultadoAcao(ex);
            }
        }
    }
}
