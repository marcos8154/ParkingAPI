using ParkingAPI.Commands.Acoes.Cobr;
using ParkingAPI.Commands.ViewModels;
using ParkingAPI.Dominio;
using ParkingAPI.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingAPI.Commands.Manipuladores.Cobr
{
    internal sealed class ConsultaCobranca : ManipuladorComando<ConsultarCobranca>
    {
        protected override ResultadoAcao ManipulaComando(ConsultarCobranca cmd)
        {
            try
            {
                IEstadiaRepository estRepos = ObterInstanciaRepos<IEstadiaRepository>();
                ICobrancaRepository cobrRepos = ObterInstanciaRepos<ICobrancaRepository>();
                Cobranca cobranca = cobrRepos
                    .Where(c => c.CodigoCobranca.Equals(cmd.CodigoCobranca))
                    .FirstOrDefault();

                if (cobranca == null) return new ResultadoAcao($"Cobrança não localizada pelo código '{cmd.CodigoCobranca}'", StatusRetorno.NotFound);

                CobrancaViewModel vm = new CobrancaViewModel(cobranca);
                return new ResultadoAcao(vm);
            }
            catch (Exception ex)
            {
                return new ResultadoAcao(ex);
            }
        }
    }
}
