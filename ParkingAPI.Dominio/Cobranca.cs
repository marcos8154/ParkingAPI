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
        public virtual Placa Placa { get; private set; }

        public Cobranca(Placa placa, decimal valor, string descricao)
        {
            Id = Guid.NewGuid();

            DataHora = DateTime.Now;
            Valor = valor;
            Descricao = descricao;
        }
    }
}
