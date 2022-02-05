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
    internal sealed class PesquisadorListaProprietarios : ManipuladorComando<BuscarProprietarioPorTipo>
    {
        private readonly IProprietarioRepository propRepos;
        public PesquisadorListaProprietarios()
        {
            propRepos = IoC.Resolve<IProprietarioRepository>();
        }

        protected override ResultadoAcao ManipulaComando(BuscarProprietarioPorTipo cmd)
        {
            try
            {
                cmd.Valida();

                List<Proprietario> proprietarios = propRepos.Where(p => 
                        p.CpfCnpj.Contains(cmd.Busca) ||
                        p.Nome.Contains(cmd.Busca) ||
                        p.Logradouro.Contains(cmd.Busca) ||
                        p.Rg.Contains(cmd.Busca) ||
                        p.Telefone.Contains(cmd.Busca))
                    .ToList();

                return new ResultadoAcao(proprietarios);
            }
            catch (Exception ex)
            {
                return new ResultadoAcao(ex);
            }
        }
    }
}
