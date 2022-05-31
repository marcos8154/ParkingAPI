using ParkingAPI.Commands.Manipuladores.FormaPag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingAPI.Commands.Acoes.FormaPag
{
    public class CriarFormaPag : IComandoAPI
    {
        public string Nome { get; set; }

        public async Task<IResultadoAcao> Executar()
        {
            return await new CriadorFormaPag().Manipular(this);
        }

        public void Valida()
        {
            if (string.IsNullOrEmpty(Nome)) 
                throw new Exception("Informe um nome para a forma de pagamento");
        }
    }
}
