using IoCdotNet;
using ParkingAPI.Commands.Acoes.Estadi;
using ParkingAPI.Commands.ViewModels;
using ParkingAPI.Dominio;
using ParkingAPI.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingAPI.Commands.Manipuladores.Estadi
{
    internal sealed class SairPlaca : ManipuladorComando<SaidaPlaca>
    {
        private readonly IEstadiaRepository estaRepos;
        private readonly ICobrancaRepository cobRepos;
        public SairPlaca()
        {
            estaRepos = IoC.Resolve<IEstadiaRepository>();
            cobRepos = IoC.Resolve<ICobrancaRepository>();
        }

        protected override ResultadoAcao ManipulaComando(SaidaPlaca cmd)
        {
            try
            {
                cmd.Valida();

                Estadia esta = estaRepos.ObterEstadiaAbertaPorPlaca(placa: cmd.PlacaVeiculo);

                if (esta == null)
                    return new ResultadoAcao("Não foi encontrado estadia aberta para essa placa", StatusRetorno.NotFound);

                Cobranca cob = esta.Saida();
                cobRepos.Add(cob);

                CobrancaViewModel saida = new CobrancaViewModel(cob, esta);

                estaRepos.Update(esta);

                return new ResultadoAcao(saida);
            }
            catch (Exception ex)
            {
                return new ResultadoAcao(ex);
            }
        }
    }
}
