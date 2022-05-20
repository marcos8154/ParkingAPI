using CFIS.Misc;
using ParkingAPI.Commands.Manipuladores.Pla;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingAPI.Commands.Acoes.Pla
{
    public class AtualizarPlaca : CriarPlaca
    {
        public new async Task<IResultadoAcao> Executar()
        {
            return await new AtualizadorPlaca().Manipular(this);
        }

        public new void Valida()
        {
            if (string.IsNullOrEmpty(PlacaVeiculo))
                throw new Exception("A placa do veículo é obrigátória");
        }
    }
}
