using ParkingAPI.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingAPI.Commands.ViewModels
{
    public class FormaPagamentoViewModel
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Inativo { get; set; }

        public FormaPagamentoViewModel(FormaPagamento fpg)
        {
            Id = fpg.Id.ToString();
            Nome = fpg.Nome;
            Inativo = (fpg.Inativo ? "Sim" : "Não");
        }
    }
}
