using IoCdotNet;
using ParkingAPI.Commands.Acoes.Prop;
using ParkingAPI.Dominio;
using ParkingAPI.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkingAPI.Dominio.DTO;

namespace ParkingAPI.Commands.Manipuladores.Prop
{
    internal sealed class BuscadorProprietario : ManipuladorComando<BuscarProprietario>
    {
        private readonly IProprietarioRepository propRepos;
        public BuscadorProprietario()
        {
            propRepos = IoC.Resolve<IProprietarioRepository>();
        }

        protected override ResultadoAcao ManipulaComando(BuscarProprietario cmd)
        {
            try
            {
                IReadOnlyCollection<Proprietario> pro = propRepos.FindAll();

                return new ResultadoAcao(pro);
            }
            catch (Exception ex)
            {
                return new ResultadoAcao(ex);
            }
        }
    }
}
