using ParkingAPI.Commands.Manipuladores.Pla;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingAPI.Commands.Acoes.Pla
{
    public class ExcluirPlaca : IComandoAPI
    {
        public string placa { get; set; }

        public  async Task<IResultadoAcao> Executar()
        {
            return await new ExcluidorPlaca().Manipular(this);
        }

        public void Valida()
        {
            if (string.IsNullOrEmpty(placa))
                throw new Exception("A placa do veículo é obrigátória");
        }
    }
}
