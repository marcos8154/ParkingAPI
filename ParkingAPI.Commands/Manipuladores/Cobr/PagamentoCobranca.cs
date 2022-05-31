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
                cmd.Valida();
                IFormaPagamentoRepository fpgRepos = ObterInstanciaRepos<IFormaPagamentoRepository>();
                ICobrancaRepository cRepos = ObterInstanciaRepos<ICobrancaRepository>();
                Cobranca cobranca = cRepos.ObterPorCodigo(cmd.CodigoCobranca);

                if (cobranca == null)
                    throw new Exception($"Cobrança não localizada pelo código '{cmd.CodigoCobranca}'");

                if (cmd.Pagamentos.Sum(p => p.Valor) != cobranca.Valor)
                    throw new Exception($"O total informado dos pagamentos (R$ {cmd.Pagamentos.Sum(p => p.Valor):N2}) é diferente do valor da cobrança (R$ {cobranca.Valor:N2})");

                foreach (PagamentoInputModel pagVm in cmd.Pagamentos)
                {
                    FormaPagamento fpg = fpgRepos.Find(pagVm.FormaPagamentoId);
                    if (fpg == null) throw new Exception($"Forma de pagamento não localizada pela Id '{pagVm.FormaPagamentoId}'");
                    cobranca.AdicionaPagamento(fpg, pagVm.Valor);
                }

                cRepos.Update(cobranca);

                CobrancaViewModel vm = new CobrancaViewModel(cobranca);

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
