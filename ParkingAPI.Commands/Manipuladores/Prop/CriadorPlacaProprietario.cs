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
    internal sealed class CriadorPlacaProprietario : ManipuladorComando<CriarPlacaProprietario>
    {
        private readonly IProprietarioRepository propRepos;
        private readonly IPlacaRepository placaRepos;
        public CriadorPlacaProprietario()
        {
            propRepos = IoC.Resolve<IProprietarioRepository>();
            placaRepos = IoC.Resolve<IPlacaRepository>();
        }

        protected override ResultadoAcao ManipulaComando(CriarPlacaProprietario cmd)
        {
            try
            {
                cmd.Valida();

                Proprietario pro = propRepos.ObterPorCpfCnpj(cpfCnpj: cmd.CpfCnpj);

                if(pro == null)
                    throw new Exception("Proprietário não encontrado");

                Placa pla = new Placa(
                    id: cmd.placa, 
                    descricaoVeiculo: cmd.descricaoVeiculo, 
                    padrao: cmd.padrao
                );

                pla.DefineProprietario(pro);

                placaRepos.Add(pla);

                return new ResultadoAcao("Placa adicionada ao Proprietário");
            }
            catch (Exception ex)
            {
                return new ResultadoAcao(ex);
            }
        }
    }
}
