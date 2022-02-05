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
    internal sealed class AtualizadorPlaca : ManipuladorComando<AtualizarPlaca>
    {
        private readonly IPlacaRepository plaRepos;
        private readonly IProprietarioRepository propRepos;
        public AtualizadorPlaca()
        {
            plaRepos = IoC.Resolve<IPlacaRepository>();
            propRepos = IoC.Resolve<IProprietarioRepository>();
        }

        protected override ResultadoAcao ManipulaComando(AtualizarPlaca cmd)
        {
            try
            {
                cmd.Valida();

                Placa pla = plaRepos.Find(id: cmd.PlacaVeiculo);
                pla.AtualizaInfo(
                    id: cmd.PlacaVeiculo,
                    descricaoVeiculo: cmd.DescricaoVeiculo,
                    prioritaria: cmd.PlacaPrioritaria
                );

                if (!string.IsNullOrEmpty(cmd.CpfCnpjProprietario))
                {
                    Proprietario pro = propRepos.ObterPorCpfCnpj(cpfCnpj: cmd.CpfCnpjProprietario);
                    if (pro == null)
                        throw new Exception("Proprietário não encontrado");

                    pla.DefineProprietario(pro);
                }

                plaRepos.Update(pla);
                return new ResultadoAcao("Placa atualizada");
            }
            catch (Exception ex)
            {
                return new ResultadoAcao(ex);
            }
        }
    }
}
