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
    internal sealed class BuscadorProprietarioPorTipo : ManipuladorComando<BuscarProprietarioPorTipo>
    {
        private readonly IProprietarioRepository propRepos;
        public BuscadorProprietarioPorTipo()
        {
            propRepos = IoC.Resolve<IProprietarioRepository>();
        }

        protected override ResultadoAcao ManipulaComando(BuscarProprietarioPorTipo cmd)
        {
            try
            {
                cmd.Valida();

                Proprietario pro = propRepos.ObterPorTipo(tipo: cmd.Tipo, pesquisa: cmd.Busca);

                return new ResultadoAcao(pro);
            }
            catch (Exception ex)
            {
                return new ResultadoAcao(ex);
            }
        }
    }
}
