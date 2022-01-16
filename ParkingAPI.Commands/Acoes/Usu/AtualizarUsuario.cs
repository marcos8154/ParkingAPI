using ParkingAPI.Commands.Manipuladores.Usu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingAPI.Commands.Acoes.Usu
{
    public class AtualizarUsuario : IComandoAPI
    {
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }

        public  async Task<IResultadoAcao> Executar()
        {
            return await new AtualizadorUsuario().Manipular(this);
        }

        public void Valida()
        {
            if (string.IsNullOrEmpty(Nome))
                throw new Exception("O nome é obrigatório");
            if (string.IsNullOrEmpty(Login))
                throw new Exception("O login é obrigatório");
            if (string.IsNullOrEmpty(Senha))
                throw new Exception("A senha é obrigatório");
        }
    }
}
