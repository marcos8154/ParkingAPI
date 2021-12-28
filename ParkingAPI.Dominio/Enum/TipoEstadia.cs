using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingAPI.Dominio.Enum
{
    public enum TipoEstadia
    {  
        
       /// <summary>
       /// O conceito de mensalista é pago no fim do mes (fixa) <br/>
       /// pra usar essa vaga durante o mes. <br/>
       /// 
       /// Não há limite de consumo
       /// </summary>
        Mensalista = 1,

        /// <summary>
        /// Rotativa gera cobrança para pagamento imediato na saída
        /// </summary>
        Rotativa = 2
    }
}
