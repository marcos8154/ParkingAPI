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
using ParkingAPI.Commands.ViewModels;

namespace ParkingAPI.Commands.Manipuladores.Prop
{
    internal sealed class ObterProprietarioPorDocumento : ManipuladorComando<Acoes.Prop.BuscarProprietarioPorDoc>
    {
        private readonly IProprietarioRepository propRepos;
        public ObterProprietarioPorDocumento()
        {
            propRepos = IoC.Resolve<IProprietarioRepository>();
        }

        protected override ResultadoAcao ManipulaComando(Acoes.Prop.BuscarProprietarioPorDoc cmd)
        {
            try
            {
                cmd.Valida();

                Proprietario pro = propRepos.ObterPorCpfCnpj(cpfCnpj: cmd.CpfCnpj);
                if (pro == null) return new ResultadoAcao($"Proprietário não localizado pelo CPF/CNPJ '{cmd.CpfCnpj}'", StatusRetorno.NotFound);

                ProprietarioViewModel vm = new ProprietarioViewModel(pro);

                return new ResultadoAcao(vm);
            }
            catch (Exception ex)
            {
                return new ResultadoAcao(ex);
            }
        }
    }
}
