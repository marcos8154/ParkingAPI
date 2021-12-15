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

        public Estacionamento(string nome, string cNPJ, int tempoestadia, decimal valorestadia)
        {
            Id = Guid.NewGuid();
            if (string.IsNullOrEmpty(nome))
                throw new Exception("O nome é obrigátório");

            Nome = nome;
            CNPJ = cNPJ;
            TempoEstadia = tempoestadia;
            ValorEstadia = valorestadia;

            Estadias = new List<Estadia>();
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
