using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingAPI.Dominio
{
    public class PagamentoEstadia
    {
        public Guid Id { get; private set; }
        public Guid CobrancaId { get; private set; }
        public Guid FormaPagamentoId { get; private set; }
        public decimal ValorPagamento { get; private set; }

        public virtual FormaPagamento FormaPagamento { get; private set; }
        public virtual Cobranca Cobranca { get; private set; }

        public PagamentoEstadia(Cobranca cobranca, FormaPagamento formaPag, decimal valor)
        {
            if (cobranca == null) throw new Exception("A estadia não foi especificada para o pagamento");
            if (formaPag == null) throw new Exception("A forma de pagamento não foi especificada para o pagamento");
            if (valor <= 0) throw new Exception("O valor do pagamento não pode ser superior a zero");
            if (valor > cobranca.Valor) throw new Exception("O valor do pagamento não pode ser superior ao valor total da estadia");

            Id = Guid.NewGuid();
            CobrancaId = cobranca.Id;
            FormaPagamentoId = formaPag.Id;
            ValorPagamento = Math.Round(valor, 2, MidpointRounding.AwayFromZero);
        }

        public PagamentoEstadia() { }
    }
}
