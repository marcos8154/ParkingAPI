using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingAPI.Commands
{
    public interface IResultadoAcao
    {
        int Status { get; }
        string Message { get; }
        object Data { get; }
    }
}
