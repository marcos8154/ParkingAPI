using ParkingAPI.Commands.Manipuladores.Prop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkingAPI.Dominio.Enum;

namespace ParkingAPI.Commands.Acoes.Prop
{
    public class ExcluirProprietario : IComandoAPI
    {
        public string CpfCnpj { get; set; }

        public  async Task<IResultadoAcao> Executar()
        {
            return await new ExcluidorProprietario().Manipular(this);
        }

        public void Valida()
        {
            if (string.IsNullOrEmpty(CpfCnpj))
                throw new Exception("O CPF / CNPJ é obrigátório");
        }
    }
}
