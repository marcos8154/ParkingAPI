using ParkingAPI.Commands.Manipuladores.FormaPag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingAPI.Commands.Acoes.FormaPag
{
    public class PesquisarFormaPag : IComandoAPI
    {
        public string Busca { get; set; }
        public bool VerInativos { get; set; }
        public async Task<IResultadoAcao> Executar()
        {
            return await new BuscadorFormaaPag().Manipular(this);
        }

        public void Valida()
        {
            if (Busca == null)
                Busca = string.Empty;
        }
    }
}
