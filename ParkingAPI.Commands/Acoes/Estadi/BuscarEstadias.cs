using ParkingAPI.Commands.Manipuladores.Estadi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingAPI.Commands.Acoes.Estadi
{
    public class BuscarEstadias : IComandoAPI
    {
        public string CNPJEstacionamento { get; set; }
        public string PlacaVeiculo { get; set; }
        public bool ApenasEmAberto { get; set; }

        public  async Task<IResultadoAcao> Executar()
        {
            return await new BuscadorEstadias().Manipular(this);
        }

        public void Valida()
        {

        }
    }
}
