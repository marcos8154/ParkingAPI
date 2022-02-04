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
    internal sealed class CriadorPlaca : ManipuladorComando<CriarPlaca>
    {
        private readonly IPlacaRepository placaRepos;
        public CriadorPlaca()
        {
            placaRepos = IoC.Resolve<IPlacaRepository>();
        }

        protected override ResultadoAcao ManipulaComando(CriarPlaca cmd)
        {
            try
            {
                cmd.Valida();

                Placa pla = new Placa(
                    codigoPlaca: cmd.placa, 
                    descricaoVeiculo: cmd.descricaoVeiculo
                );

                placaRepos.Add(pla);

                return new ResultadoAcao("Placa adicionada");
            }
            catch (Exception ex)
            {
                return new ResultadoAcao(ex);
            }
        }
    }
}
