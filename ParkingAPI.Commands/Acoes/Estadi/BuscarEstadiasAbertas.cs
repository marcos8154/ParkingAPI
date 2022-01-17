using ParkingAPI.Commands.Manipuladores.Estadi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingAPI.Commands.Acoes.Estadi
{
    public class BuscarEstadiasAbertas : IComandoAPI
    {
        public  async Task<IResultadoAcao> Executar()
        {
            return await new BuscadorEstadiasAbertas().Manipular(this);
        }

        public void Valida()
        {

        }
    }
}
