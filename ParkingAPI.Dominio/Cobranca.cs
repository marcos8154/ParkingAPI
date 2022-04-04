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

        public Cobranca(Placa placa, decimal valor, string descricao,
            Estadia estadia = null)
        {
            Id = Guid.NewGuid();

            string[] arrayGuid = Id.ToString().Split('-');
            string ultimoBlocoGuid = arrayGuid[arrayGuid.Length - 1];
            CodigoCobranca = ultimoBlocoGuid.ToUpper();

            PlacaId = placa.Id;
            DataHora = DateTime.Now;
            Valor = valor;
            Descricao = descricao;
            EstadiaId = estadia == null ? null : estadia.Id;
        }

        public void DefinirPago()
        {
            Pago = true;
            DataPagamento = DateTime.Now;
        }
    }
}
