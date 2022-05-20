using ParkingAPI.Dominio;
using ParkingAPI.Dominio.Enum;
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

        public string DataEntradaVeiculo { get; set; }
        public string DataSaidaVeiculo { get; set; }

        public string ModalidadeEstadia { get; set; }

        public string Placa { get; set; }
        public string Veiculo { get; set; }
        public string Proprietario { get; set; }
        public string Estacionamento { get; set; }
        public string TempoConsumo { get; set; }
        public string Pago { get; set; }
        public string DataPagamento { get; set; }
        public decimal Valor { get; set; }

        public CobrancaViewModel(Cobranca cobranca)
        {
            Fill(cobranca, cobranca.Estadia);
        }

        public CobrancaViewModel(Cobranca cobranca, Estadia estadia)
        {
            Fill(cobranca, estadia);
        }

        private void Fill(Cobranca cobranca, Estadia estadia)
        {
            Placa placa = estadia.Placa;
            Proprietario proprietario = placa.Proprietario;
            Estacionamento estacionamento = estadia.Estacionamento;

            DataEntradaVeiculo = estadia.DataEntrada.ToString("dd/MM/yyyy HH:mm");
            DataSaidaVeiculo = estadia.DataSaida.Value.ToString("dd/MM/yyyy HH:mm");
            ModalidadeEstadia = estadia.Tipo == TipoEstadia.Mensalista ? "MENSALISTA" : "ROTATIVO";
            Valor = cobranca.Valor;
            TempoConsumo = estadia.TempoConsumo;
            CodigoCobranca = cobranca.CodigoCobranca;
            DataEmissao = cobranca.DataHora;
            Placa = placa.Id;
            Veiculo = placa.DescricaoVeiculo;
            Estacionamento = $"{estacionamento.Nome} - {estacionamento.CNPJ}";
            Pago = cobranca.Pago ? "SIM" : "NÃO";
            DataPagamento = cobranca.Pago ? cobranca.DataPagamento.Value.ToString("dd/MM/yyyy HH:mm") : string.Empty;

            string codigoFormatado = "";

            for (int i = 0; i < CodigoCobranca.Length; i += 2)
            {
                codigoFormatado += $"{CodigoCobranca[i]}{CodigoCobranca[i + 1]} ";
            }

            CodigoCobranca = codigoFormatado.Substring(0, codigoFormatado.Length - 1);

            if (proprietario == null)
                Proprietario = "SEM PROPRIETÁRIO VINCULADO";
            else
            {
                string cpfMascarado = string.Empty;
                for (int i = 0; i < proprietario.CpfCnpj.Length; i++)
                {
                    if (i >= 3 && i <= 8) cpfMascarado += "*";
                    else cpfMascarado += proprietario.CpfCnpj[i];
                }
                Proprietario = $"{proprietario.Nome} - {cpfMascarado}";
            }
        }
    }
}
