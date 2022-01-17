using ParkingAPI.Commands.Manipuladores.Estaciona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingAPI.Commands.Acoes.Estaciona
{
    public class BuscarEstacionamentoPorCnpj : IComandoAPI
    {
        public string CNPJ { get; set; }

        public  async Task<IResultadoAcao> Executar()
        {
            return await new BuscadorEstacionamentoPorCnpj().Manipular(this);
        }

        public void Valida()
        {
            if (string.IsNullOrEmpty(CNPJ))
                throw new Exception("O CNPJ é obrigatório");
        }
    }
}
