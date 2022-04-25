using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingAPI.Dominio
{
    public class Cobranca
    {
        public Guid Id { get; private set; }
        public DateTime DataHora { get; private set; }
        public decimal Valor { get; private set; }
        public string Descricao { get; private set; }
        public string PlacaId { get; private set; }
        public bool Pago { get; private set; }
        public DateTime? DataPagamento { get; private set; }
        public string CodigoCobranca { get; private set; }
        public Guid? EstadiaId { get; private set; }

        public virtual Placa Placa { get; private set; }
        public virtual Estadia Estadia { get; private set; }

        public Cobranca()
        {

        }

        private void GeraCodigoCobranca()
        {
            string[] arrayGuid = Id.ToString().Split('-');
            string codigo = "";
            for (int i = 0; i < arrayGuid.Length; i++)
            {
                string primeiros2 = arrayGuid[i].Substring(0, 2);
                codigo += primeiros2;
            }
            CodigoCobranca = codigo.ToUpper();
        }

        public Cobranca(Placa placa, decimal valor, string descricao,
            Estadia estadia)
        {
            Id = Guid.NewGuid();

            GeraCodigoCobranca();

            PlacaId = placa.Id;
            DataHora = DateTime.Now;
            Valor = valor;
            Descricao = descricao;
            EstadiaId = estadia.Id;
        }

        public void DefinirPago()
        {
            Pago = true;
            DataPagamento = DateTime.Now;
        }
    }
}
