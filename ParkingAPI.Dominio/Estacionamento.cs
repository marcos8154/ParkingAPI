using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingAPI.Dominio
{
    public class Estacionamento
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string CNPJ { get; private set; }
        public int TempoEstadia { get; private set; }
        public decimal ValorEstadia { get; private set; }
        public virtual List<Estadia> Estadias { get; private set; }

        public Estacionamento(string nome, string cNPJ)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            CNPJ = cNPJ;

            Estadias = new List<Estadia>();
        }

        public Estacionamento()
        {

        }

        internal decimal CalculaValorEstadia(Estadia estadia)
        {
            double totalMinutos = estadia.TotalMinutos();
            int ciclosEstadia = (int)totalMinutos / TempoEstadia;
            decimal valorEstadia = ciclosEstadia * ValorEstadia;
            valorEstadia = decimal.Round(valorEstadia, 2, MidpointRounding.ToEven);
            return valorEstadia;
        }
    }
}
