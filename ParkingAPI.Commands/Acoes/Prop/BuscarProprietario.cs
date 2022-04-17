using ParkingAPI.Commands.Manipuladores.Prop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkingAPI.Dominio.Enum;

namespace ParkingAPI.Commands.Acoes.Prop
{
    public class BuscarProprietario : IComandoAPI
    {

        public  async Task<IResultadoAcao> Executar()
        {
            return await new ObterProprietario().Manipular(this);
        }

        public void Valida()
        {
            
        }
    }
}
