using ParkingAPI.Commands.Manipuladores.Pla;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingAPI.Commands.Acoes.Pla
{
    public class BuscarPlaca : IComandoAPI
    {
        public string PlacaVeiculo { get; set; }

        public BuscarPlaca(string placaVeiculo)
        {
            PlacaVeiculo = placaVeiculo;
        }

        public  async Task<IResultadoAcao> Executar()
        {
            return await new BuscadorPlaca().Manipular(this);
        }

        public void Valida()
        {
            if (string.IsNullOrEmpty(PlacaVeiculo))
                throw new Exception("A placa do veículo não foi informada");
        }
    }
}
