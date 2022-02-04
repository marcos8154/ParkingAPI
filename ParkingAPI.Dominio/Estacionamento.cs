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

        public Estacionamento(string nome, string cnpj, int tempoestadia, decimal valorestadia)
        {
            Id = Guid.NewGuid();
            if (string.IsNullOrEmpty(nome))
                throw new Exception("O nome é obrigátório");

            CNPJ = cnpj;
            AtualizaInfo(nome, tempoestadia, valorestadia);

            Estadias = new List<Estadia>();
        }

        private Estacionamento()
        {

        }

        public void AtualizaInfo(string nome, int tempoEstadia, decimal valorEstadia)
        {
            if (string.IsNullOrEmpty(nome)) throw new Exception("O nome é obrigatório");
            if (tempoEstadia <= 0) throw new Exception("O tempo de estadia é obrigatório");
            if (valorEstadia <= 0) throw new Exception("O valor da estadia é obrigatório");

            Nome = nome;
            TempoEstadia = tempoEstadia;
            ValorEstadia = valorEstadia;
        }

        internal decimal CalculaValorEstadia(Estadia estadia)
        {
            double totalMinutos = estadia.TotalMinutos();
            int ciclosEstadia = (int)(totalMinutos / TempoEstadia);
            decimal valorEstadia = ciclosEstadia * ValorEstadia;
            valorEstadia = decimal.Round(valorEstadia, 2, MidpointRounding.ToEven);
            return valorEstadia;
        }
    }
}
