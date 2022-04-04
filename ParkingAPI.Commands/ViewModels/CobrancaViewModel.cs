using ParkingAPI.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingAPI.Commands.ViewModels
{
    public class CobrancaViewModel
    {
        public string CodigoCobranca { get; set; }
        public DateTime DataEmissao { get; set; }

        public DateTime DataEntradaVeiculo { get; set; }
        public DateTime DataSaidaVeiculo { get; set; }

        public string Placa { get; set; }
        public string Veiculo { get; set; }
        public string Proprietario { get; set; }
        public string Estacionamento { get; set; }
        public string TempoConsumo { get; set; }
        public string Pago { get; set; }
        public string DataPagamento { get; set; }

        public CobrancaViewModel(Cobranca cobranca)
        {
            Estadia estadia = cobranca.Estadia;
            Placa placa = estadia.Placa;
            Proprietario proprietario = placa.Proprietario;
            Estacionamento estacionamento = estadia.Estacionamento;

            DataEntradaVeiculo = estadia.DataEntrada;
            DataSaidaVeiculo = estadia.DataSaida.Value;

            TempoConsumo = estadia.TempoConsumo;
            CodigoCobranca = cobranca.CodigoCobranca;
            DataEmissao = cobranca.DataHora;
            Placa = placa.Id;
            Veiculo = placa.DescricaoVeiculo;
            Estacionamento = $"{estacionamento.Nome} - {estacionamento.CNPJ}";
            Pago = cobranca.Pago ? "SIM" : "NÃO";
            DataPagamento = cobranca.Pago ? cobranca.DataPagamento.Value.ToString("dd/MM/yyyy HH:mm") : string.Empty;

            if (proprietario == null)
                Proprietario = "SEM PROPRIETÁRIO VINCULADO";
            else
            {
                string cpfMascarado = string.Empty;
                for (int i = 0; i < proprietario.CpfCnpj.Length; i++)
                {
                    if (i < 6) cpfMascarado += "*";
                    else cpfMascarado += proprietario.CpfCnpj[i];
                }
                Proprietario = $"{proprietario.Nome} - {cpfMascarado}";
            }
        }
    }
}
