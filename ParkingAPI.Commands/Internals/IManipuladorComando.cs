using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingAPI.Commands
{
    internal interface IManipuladorComando
    {
        Task<IResultadoAcao> Manipular(IComandoAPI cmd);
    }
}
