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
    internal sealed class BuscadorCobrancasPorPlaca : ManipuladorComando<ListarCobrancasPorPlaca>
    {
        protected override ResultadoAcao ManipulaComando(ListarCobrancasPorPlaca cmd)
        {
            try
            {
                cmd.Valida();
                ICobrancaRepository cRepos = ObterInstanciaRepos<ICobrancaRepository>();
                IQueryable<Cobranca> query = null;

                if (cmd.TodoOPeriodo)
                {
                    query = cRepos
                    .Where(c => c.PlacaId.Equals(cmd.PlacaVeiculo));
                }
                else
                {
                    query = cRepos
                    .Where(c =>
                        c.PlacaId.Equals(cmd.PlacaVeiculo) &&
                       (c.DataHora >= cmd.DataInicio.Value && c.DataHora <= cmd.DataFim.Value)); ;
                }

                if (cmd.Situacao.Equals(ListarCobrancasPorPlaca.SITUACAO_PAGO))
                    query = query.Where(c => c.Pago == true);
                if (cmd.Situacao.Equals(ListarCobrancasPorPlaca.SITUACAO_NAO_PAGO))
                    query = query.Where(c => c.Pago == false);
                if (cmd.Situacao.Equals(ListarCobrancasPorPlaca.SITUACAO_TODOS))
                    query = query.Where(c => c.Pago == true || c.Pago == false);

                List<Cobranca> cobrancas = query.ToList();
                List<CobrancaViewModel> vms = new List<CobrancaViewModel>();
                cobrancas.ForEach(c => vms.Add(new CobrancaViewModel(c, c.Estadia)));

                return new ResultadoAcao($"{vms.Count} cobranças encontradas", vms);
            }
            catch (Exception ex)
            {
                return new ResultadoAcao(ex);
            }
        }
    }
}
