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
        public string PlacaId { get; private set; }
        public Guid EstacionamentoId { get; private set; }
        public virtual Placa Placa { get; private set; }
        public virtual Estacionamento Estacionamento { get; private set; }

        public Estadia(Estacionamento estacionamento, Placa placa)
        {
            Id = Guid.NewGuid();

            EstacionamentoId = estacionamento.Id;
            PlacaId = placa.Id;
            DataEntrada = DateTime.Now;
        }

        public double TotalMinutos()
        {
            if (DataSaida == null) return 0;

            double totalMin = ((DateTime)DataSaida - DataEntrada).TotalMinutes;
            return totalMin;
        }

        public Cobranca Saida()
        {
            if (Estacionamento == null) return null;

            DataSaida = DateTime.Now;
            decimal valor = Estacionamento.CalculaValorEstadia(this);
            Cobranca cobrancaEstacionamento = new Cobranca(Placa, valor, $"Estadia de '{PlacaId}' por {TotalMinutos()} minutos");
            return cobrancaEstacionamento;
        }
    }
}
