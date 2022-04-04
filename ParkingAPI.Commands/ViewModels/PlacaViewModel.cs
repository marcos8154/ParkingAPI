using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingAPI.Commands.ViewModels
{
    public class PlacaViewModel
    {
        public string Proprietario { get; set; }
        public string Placa { get; set; }
        public string Veiculo { get; set; }
        public bool Prioritaria { get; set; }

        public PlacaViewModel(string proprietario, string placa, string veiculo, bool prioritaria)
        {
            Proprietario = proprietario;
            Placa = placa;
            Veiculo = veiculo;
            Prioritaria = prioritaria;
        }

        public PlacaViewModel()
        {
        }
    }
}
