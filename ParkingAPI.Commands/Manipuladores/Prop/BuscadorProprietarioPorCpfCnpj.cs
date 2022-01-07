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
    internal sealed class BuscadorProprietarioPorCpfCnpj : ManipuladorComando<BuscarProprietarioPorCpfCnpj>
    {
        private readonly IProprietarioRepository propRepos;
        public BuscadorProprietarioPorCpfCnpj()
        {
            propRepos = IoC.Resolve<IProprietarioRepository>();
        }

        protected override ResultadoAcao ManipulaComando(BuscarProprietarioPorCpfCnpj cmd)
        {
            try
            {
                cmd.Valida();

                Proprietario pro = propRepos.ObterPorCpfCnpj(cpfCnpj: cmd.CpfCnpj);

                return new ResultadoAcao(pro);
            }
            catch (Exception ex)
            {
                return new ResultadoAcao(ex);
            }
        }
    }
}
