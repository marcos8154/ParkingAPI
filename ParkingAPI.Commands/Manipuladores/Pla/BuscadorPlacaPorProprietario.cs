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
    internal sealed class BuscadorPlacaPorProprietario : ManipuladorComando<ListarPlacasDoProprietario>
    {
        private readonly IPlacaRepository plaRepos;
        public BuscadorPlacaPorProprietario()
        {
            plaRepos = IoC.Resolve<IPlacaRepository>();
        }

        protected override ResultadoAcao ManipulaComando(ListarPlacasDoProprietario cmd)
        {
            try
            {
                cmd.Valida();

                IReadOnlyCollection<Placa> placas = plaRepos.ObterPorProprietario(cpfCnpj: cmd.CpfCnpjProprietario);
                return new ResultadoAcao(placas);
            }
            catch (Exception ex)
            {
                return new ResultadoAcao(ex);
            }
        }
    }
}
