using ParkingAPI.Commands.Acoes.FormaPag;
using ParkingAPI.Commands.ViewModels;
using ParkingAPI.Dominio;
using ParkingAPI.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingAPI.Commands.Manipuladores.FormaPag
{
    internal sealed class BuscadorFormaaPag : ManipuladorComando<PesquisarFormaPag>
    {
        protected override ResultadoAcao ManipulaComando(PesquisarFormaPag cmd)
        {
            cmd.Valida();
            IFormaPagamentoRepository db = ObterInstanciaRepos<IFormaPagamentoRepository>();
            List<FormaPagamento> formas = db
                .Where(fpg => fpg.Nome.Contains(cmd.Busca) &&
                    (cmd.VerInativos 
                        ? (fpg.Inativo == true || fpg.Inativo == false)
                        : fpg.Inativo == false))
                .ToList();

            List<FormaPagamentoViewModel> vms = new List<FormaPagamentoViewModel>();
            formas.ForEach(fpg => vms.Add(new FormaPagamentoViewModel(fpg)));
            return new ResultadoAcao(vms);
        }
    }
}
