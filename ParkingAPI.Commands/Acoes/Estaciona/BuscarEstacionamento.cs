using ParkingAPI.Commands.Manipuladores.Estaciona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingAPI.Commands.Acoes.Estaciona
{
    public class BuscarEstacionamento : IComandoAPI
    {

        public  async Task<IResultadoAcao> Executar()
        {
            return await new BuscadorEstacionamento().Manipular(this);
        }

        public void Valida()
        {

        }
    }
}
