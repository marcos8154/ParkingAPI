using CFIS.Misc;
using ParkingAPI.Commands.Manipuladores.Pla;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingAPI.Commands.Acoes.Pla
{
    public class AtualizarPlaca : IComandoAPI
    {
        public string PlacaVeiculo { get; set; }
        public string DescricaoVeiculo { get; set; }
        public bool PlacaPrioritaria { get; set; }

        public async Task<IResultadoAcao> Executar()
        {
            return await new AtualizadorPlaca().Manipular(this);
        }

        public void Valida()
        {
            if (string.IsNullOrEmpty(PlacaVeiculo))
                throw new Exception("A placa do veículo é obrigátória");
        }
    }
}
