using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingAPI.Commands
{
    public sealed class ResultadoAcao : IResultadoAcao
    {
        public string Message { get; }
        public object Data { get; }
        public int Status { get; }

        internal ResultadoAcao(string message = null, StatusRetorno status = StatusRetorno.OK)
        {
            Status = (int) status;
            Message = message;
        }

        internal ResultadoAcao(string message, object data, StatusRetorno status = StatusRetorno.OK)
        {
            Status = (int)status;
            Message = message;
            Data = data;
        }

        internal ResultadoAcao(object data, StatusRetorno status = StatusRetorno.OK)
        {
            Status = (int)status;
            Data = data;
        }

        internal ResultadoAcao(Exception ex, StatusRetorno status = StatusRetorno.BadRequest)
        {
            Status = (int)status;
            Message = ex.Message;
            if (ex.InnerException != null)
                Message += $"\n{ex.InnerException.Message}";
        }
    }
}
