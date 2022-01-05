using ParkingAPI.Commands.Manipuladores.Prop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkingAPI.Dominio.Enum;

namespace ParkingAPI.Commands.Acoes.Prop
{
    public class CriarPlacaProprietario : IComandoAPI
    {
        public string idProprietario { get; set; }
        public string placa { get; set; }
        public string descricaoVeiculo { get; set; }
        public Boolean padrao { get; private set; }

        public  async Task<IResultadoAcao> Executar()
        {
            return await new AtualizadorProprietario().Manipular(this);
        }

        public void Valida()
        {
            if (string.IsNullOrEmpty(idProprietario))
                throw new Exception("Para incluir placa de proprietário, é obrigatório informar o Id do Proprietário");

            if (string.IsNullOrEmpty(placa))
                throw new Exception("A placa do veículo é obrigátória");
        }
    }
}
