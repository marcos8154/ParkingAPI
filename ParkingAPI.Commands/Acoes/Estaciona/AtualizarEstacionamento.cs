using ParkingAPI.Commands.Manipuladores.Estaciona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingAPI.Commands.Acoes.Estaciona
{
    public class AtualizarEstacionamento : IComandoAPI
    {
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public int TempoEstadia { get; set; }
        public decimal ValorEstadia { get; set; }

        public  async Task<IResultadoAcao> Executar()
        {
            return await new AtualizadorEstacionamento().Manipular(this);
        }

        public void Valida()
        {
            if (string.IsNullOrEmpty(Nome))
                throw new Exception("O nome é obrigatório");
            if (string.IsNullOrEmpty(CNPJ))
                throw new Exception("O CNPJ é obrigatório");
            if (TempoEstadia <= 0)
                throw new Exception("O tempo de estadia é obrigatório");
            if (ValorEstadia <= 0)
                throw new Exception("O valor da estadia é obrigatório");
        }
    }
}
