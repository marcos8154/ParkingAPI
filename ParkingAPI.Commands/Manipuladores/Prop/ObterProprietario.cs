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
    internal sealed class ObterProprietario : ManipuladorComando<BuscarProprietario>
    {
        private readonly IProprietarioRepository propRepos;
        public ObterProprietario()
        {
            propRepos = IoC.Resolve<IProprietarioRepository>();
        }

        protected override ResultadoAcao ManipulaComando(BuscarProprietario cmd)
        {
            try
            {
                cmd.Valida();
                //gambiarra pra mostrar todos
                List<Proprietario> proprietarios = propRepos.Where(p =>
                        p.CpfCnpj.Length>0).ToList();

                List<ProprietarioViewModel> vms = new List<ProprietarioViewModel>();
                proprietarios.ForEach(p => vms.Add(new ProprietarioViewModel(p)));

                return new ResultadoAcao(vms);
            }
            catch (Exception ex)
            {
                return new ResultadoAcao(ex);
            }
        }
    }
}
