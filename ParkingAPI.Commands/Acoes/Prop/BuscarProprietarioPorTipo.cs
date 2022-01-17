using ParkingAPI.Commands.Manipuladores.Prop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkingAPI.Dominio.Enum;

namespace ParkingAPI.Commands.Acoes.Prop
{
    public class BuscarProprietarioPorTipo : IComandoAPI
    {
        public int Tipo { get; set; }
        public string Busca { get; set; }

        public  async Task<IResultadoAcao> Executar()
        {
            return await new BuscadorProprietarioPorTipo().Manipular(this);
        }

        public void Valida()
        {
            
        }
    }
}
