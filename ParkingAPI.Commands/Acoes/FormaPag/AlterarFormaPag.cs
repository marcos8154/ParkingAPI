using ParkingAPI.Commands.Manipuladores.FormaPag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingAPI.Commands.Acoes.FormaPag
{
    public class AlterarFormaPag : CriarFormaPag
    {
        public Guid Id { get; set; }
        public bool Inativo { get; set; }

        public new async Task<IResultadoAcao> Executar()
        {
            return await new AtualizadorFormaPag().Manipular(this);
        }

        public new void Valida()
        {
            if (Guid.Empty.Equals(Id))
                throw new Exception("Um Id de forma de pagamento existente é necessário para alterar o cadastro");

            if (string.IsNullOrEmpty(Nome))
                throw new Exception("Informe um nome para a forma de pagamento");
        }
    }
}
