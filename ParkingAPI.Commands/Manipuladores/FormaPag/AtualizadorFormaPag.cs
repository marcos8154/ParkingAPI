using ParkingAPI.Commands.Acoes.FormaPag;
using ParkingAPI.Dominio;
using ParkingAPI.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingAPI.Commands.Manipuladores.FormaPag
{
    internal sealed class AtualizadorFormaPag : ManipuladorComando<AlterarFormaPag>
    {
        protected override ResultadoAcao ManipulaComando(AlterarFormaPag cmd)
        {
            try
            {
                cmd.Valida();
                IFormaPagamentoRepository repos = ObterInstanciaRepos<IFormaPagamentoRepository>();
                FormaPagamento fpg = repos.Find(cmd.Id);
                if (fpg == null) throw new Exception($"Forma de pagamento não localizada pela Id '{cmd.Id}'");

                fpg.Atualizar(cmd.Nome, cmd.Inativo);
                
                repos.Update(fpg);
                return new ResultadoAcao("Forma pagamento atualizada");
            }
            catch (Exception ex)
            {
                return new ResultadoAcao(ex);
            }
        }
    }
}
