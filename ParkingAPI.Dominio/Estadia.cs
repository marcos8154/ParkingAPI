using ParkingAPI.Dominio.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingAPI.Dominio
{
    public class Estadia
    {
        public Guid Id { get; private set; }
        public DateTime DataEntrada { get; private set; }
        public DateTime? DataSaida { get; private set; }


        public TipoEstadia Tipo { get; private set; }

        public string Observacao { get; private set; }


        public string PlacaId { get; private set; }

        /// <summary>
        /// Contém uma placa
        /// </summary>
        public virtual Placa Placa { get; private set; }

        public Guid EstacionamentoId { get; private set; }

        /// <summary>
        /// Pertence a um estacionamento
        /// </summary>
        public virtual Estacionamento Estacionamento { get; private set; }

        public Estadia(Estacionamento estacionamento, Placa placaEntrando, TipoEstadia tipo)
        {
            Id = Guid.NewGuid();

            EstacionamentoId = estacionamento.Id;
            PlacaId = placaEntrando.Id;
            DataEntrada = DateTime.Now;
            Tipo = tipo;
        }

        private Estadia()
        {

        }

        public bool Encerrado()
        {
            return DataSaida != null;
        }

        public double TotalMinutos()
        {
            if (DataSaida == null) return 0;
            double totalMin = ((DateTime)DataSaida - DataEntrada).TotalMinutes;
            return totalMin;
        }

        public Cobranca Saida(string obs = null)
        {
            if (Estacionamento == null) return null;
            if (!string.IsNullOrEmpty(obs)) Observacao = obs;

            DataSaida = DateTime.Now;
            Cobranca cobrancaEstacionamento;
            if (Tipo == TipoEstadia.Mensalista)
            {
                //se estadia for de mensalista, gera cobrança com valor zerado
                cobrancaEstacionamento = new Cobranca(Placa, 0, $"Estadia de '{PlacaId}' (mensalista) por {TotalMinutos()} minutos");
            }
            else
            {
                decimal valor = Estacionamento.CalculaValorEstadia(this);
                cobrancaEstacionamento = new Cobranca(Placa, valor, $"Estadia de '{PlacaId}' por {TotalMinutos()} minutos");
            }

            return cobrancaEstacionamento;
        }
    }
}
