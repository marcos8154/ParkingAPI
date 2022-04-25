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
    internal class PagamentoCobranca : ManipuladorComando<EfetuarPagamentoCobranca>
    {
        protected override ResultadoAcao ManipulaComando(EfetuarPagamentoCobranca cmd)
        {
            try
            {
                ICobrancaRepository cRepos = ObterInstanciaRepos<ICobrancaRepository>();
                Cobranca cobr = cRepos
                    .Where(c => c.CodigoCobranca.Equals(cmd.CodigoCobranca))
                    .FirstOrDefault();

                if (cobr == null)
                    throw new Exception($"Cobrança não localizada pelo código '{cmd.CodigoCobranca}'");

                if (cobr.Pago)
                    throw new Exception($"Esta cobrança já foi paga no dia {cobr.DataPagamento.Value.ToString("dd/MM/yyyy HH:mm")}");

                cobr.DefinirPago();
                cRepos.Update(cobr);

                CobrancaViewModel vm = new CobrancaViewModel(cobr);

                return new ResultadoAcao(
                    message: $"O pagamento da cobrança '{vm.CodigoCobranca}' foi registrado",
                   data: vm);
            }
            catch (Exception ex)
            {
                return new ResultadoAcao(ex);
            }
        }
    }
}
