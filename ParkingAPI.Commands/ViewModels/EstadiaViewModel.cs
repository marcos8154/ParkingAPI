using ParkingAPI.Dominio;
using ParkingAPI.Dominio.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingAPI.Commands.ViewModels
{
    public class EstadiaViewModel
    {
        public EstadiaViewModel(Estadia e)
        {
            Placa placa = e.Placa;
            Proprietario proprietario = placa.Proprietario;

            DataEntrada = e.DataEntrada;
            DataSaida = e.DataSaida;
            TempoConsumo = e.TempoConsumo;
            Tipo = (e.Tipo == TipoEstadia.Mensalista
                ? "MENSALISTA"
                : "ROTATIVO");
            Observacao = e.Observacao;
            Veiculo = $"{placa.Id} - {placa.DescricaoVeiculo}";

            string cpfMascarado = string.Empty;

            if (proprietario != null)
            {
                for (int i = 0; i < proprietario.CpfCnpj.Length; i++)
                {
                    if (i >= 3 && i <= 8) cpfMascarado += "*";
                    else cpfMascarado += proprietario.CpfCnpj[i];
                }


                Proprietario = $"{proprietario.Nome} - {cpfMascarado}";
            }
        }

        public DateTime DataEntrada { get; set; }
        public DateTime? DataSaida { get; set; }
        public string TempoConsumo { get; set; }
        //MENSALISTA / ROTATIVA
        public string Tipo { get; set; }
        public string Observacao { get; set; }
        public string Proprietario { get; set; }
        public string Veiculo { get; set; }
    }
}
