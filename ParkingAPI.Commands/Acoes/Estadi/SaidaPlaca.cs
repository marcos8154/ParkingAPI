using ParkingAPI.Commands.Manipuladores.Estadi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingAPI.Commands.Acoes.Estadi
{
    public class SaidaPlaca : IComandoAPI
    {
        public string PlacaVeiculo { get; set; }

        public  async Task<IResultadoAcao> Executar()
        {
            return await new SairPlaca().Manipular(this);
        }

        public void Valida()
        {
            if (string.IsNullOrEmpty(PlacaVeiculo))
                throw new Exception("A placa do veículo é obrigátória");
        }
    }
}
