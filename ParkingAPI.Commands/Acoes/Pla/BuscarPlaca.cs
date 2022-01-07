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
        public  async Task<IResultadoAcao> Executar()
        {
            return await new BuscadorPlaca().Manipular(this);
        }

        public void Valida()
        {

        }
    }
}
