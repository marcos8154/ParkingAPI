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
        private readonly IProprietarioRepository propRepos;
        public CriadorPlaca()
        {
            placaRepos = IoC.Resolve<IPlacaRepository>();
            propRepos = IoC.Resolve<IProprietarioRepository>();
        }

        protected override ResultadoAcao ManipulaComando(CriarPlaca cmd)
        {
            try
            {
                cmd.Valida();

                Proprietario prop = propRepos.ObterPorCpfCnpj(cmd.CpfCnpjProprietario);

                Placa pla = new Placa(
                    codigoPlaca: cmd.PlacaVeiculo,
                    descricaoVeiculo: cmd.DescricaoVeiculo,
                    prioritaria: cmd.PlacaPrioritaria)
                .DefineAutorizada(cmd.PlacaAutorizada)
                .DefineProprietario(prop);

                placaRepos.Add(pla);

                return new ResultadoAcao($"Placa '{pla.Id}' adicionada");
            }
            catch (Exception ex)
            {
                return new ResultadoAcao(ex);
            }
        }
    }
}
