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
        public string Busca { get; set; }

        public BuscarProprietarioPorTipo(string busca)
        {
            Busca = busca;
        }

        public  async Task<IResultadoAcao> Executar()
        {
            return await new PesquisadorListaProprietarios().Manipular(this);
        }

        public void Valida()
        {
            if (Busca == null)
                Busca = string.Empty;
        }
    }
}
