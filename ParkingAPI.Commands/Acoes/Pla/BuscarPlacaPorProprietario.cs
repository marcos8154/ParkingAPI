using ParkingAPI.Commands.Manipuladores.Pla;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingAPI.Commands.Acoes.Pla
{
    public class BuscarPlacaPorProprietario : IComandoAPI
    {
        public string cpfCnpj { get; set; }

        public  async Task<IResultadoAcao> Executar()
        {
            return await new BuscadorPlacaPorProprietario().Manipular(this);
        }

        public void Valida()
        {
            if (string.IsNullOrEmpty(cpfCnpj))
                throw new Exception("O CPF / CNPJ é obrigátório");
        }
    }
}
