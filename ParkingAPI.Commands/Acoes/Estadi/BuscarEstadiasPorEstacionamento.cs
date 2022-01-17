using ParkingAPI.Commands.Manipuladores.Estadi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingAPI.Commands.Acoes.Estadi
{
    public class BuscarEstadiasPorEstacionamento : IComandoAPI
    {
        public string cnpj_estacionamento { get; set; }

        public  async Task<IResultadoAcao> Executar()
        {
            return await new BuscadorEstadiasPorEstacionamento().Manipular(this);
        }

        public void Valida()
        {
            if (string.IsNullOrEmpty(cnpj_estacionamento))
                throw new Exception("O CNPJ do estacionamento é obrigatório");
        }
    }
}
