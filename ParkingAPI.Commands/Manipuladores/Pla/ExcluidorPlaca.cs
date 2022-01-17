using IoCdotNet;
using ParkingAPI.Commands.Acoes.Pla;
using ParkingAPI.Dominio;
using ParkingAPI.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingAPI.Commands.Manipuladores.Pla
{
    internal sealed class ExcluidorPlaca : ManipuladorComando<ExcluirPlaca>
    {
        private readonly IPlacaRepository plaRepos;

        public ExcluidorPlaca()
        {
            plaRepos = IoC.Resolve<IPlacaRepository>();
        }

        protected override ResultadoAcao ManipulaComando(ExcluirPlaca cmd)
        {
            try
            {
                cmd.Valida();

                Placa pla = plaRepos.Find(id: cmd.placa);

                if(pla == null)
                    throw new Exception("Placa não encontrado");

                plaRepos.Remove(pla);
                return new ResultadoAcao("Placa excluída");
            }
            catch (Exception ex)
            {
                return new ResultadoAcao(ex);
            }
        }
    }
}
