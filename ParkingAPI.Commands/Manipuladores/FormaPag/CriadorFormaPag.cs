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
    internal sealed class CriadorFormaPag : ManipuladorComando<CriarFormaPag>
    {
        protected override ResultadoAcao ManipulaComando(CriarFormaPag cmd)
        {
            try
            {
                cmd.Valida();
                IFormaPagamentoRepository repos = ObterInstanciaRepos<IFormaPagamentoRepository>();
                FormaPagamento fpg = new FormaPagamento(cmd.Nome);
                repos.Add(fpg);
                return new ResultadoAcao("Forma pagamento adicionada");
            }
            catch (Exception ex)
            {
                return new ResultadoAcao(ex);
            }
        }
    }
}