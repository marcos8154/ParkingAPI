using ParkingAPI.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingAPI.Commands.ViewModels
{
    public class PagamentoViewModel
    {
        public string FormaPagamento { get; set; }
        public decimal ValorPagamento { get; set; }
        public string ValorPagamentoStr { get; set; }

        public PagamentoViewModel(PagamentoEstadia p)
        {
            FormaPagamento = p.FormaPagamento.Nome;
            ValorPagamento = p.ValorPagamento;
            ValorPagamentoStr = $"R$ {p.ValorPagamento:N2}";
        }
    }

    public class PagamentoInputModel
    {
        public Guid FormaPagamentoId { get; set; }
        public decimal Valor { get; set; }
    }
}
