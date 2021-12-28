using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingAPI.Commands
{
    public interface IComandoAPI
    {
        Task<IResultadoAcao> Executar();
        void Valida(); //pode lancar uma Exception
    }
}
