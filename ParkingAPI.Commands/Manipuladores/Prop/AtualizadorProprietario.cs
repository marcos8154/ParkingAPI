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
    internal sealed class AtualizadorProprietario : ManipuladorComando<AtualizarProprietario>
    {
        private readonly IProprietarioRepository propRepos;
        public AtualizadorProprietario()
        {
            propRepos = IoC.Resolve<IProprietarioRepository>();
        }

        protected override ResultadoAcao ManipulaComando(AtualizarProprietario cmd)
        {
            try
            {
                cmd.Valida();

                Proprietario pro = propRepos.ObterPorCpfCnpj(cpfCnpj: cmd.CpfCnpj);
                EnderecoDTO endereco = ObterEndereco(cmd);

                pro.AtualizaInfo(
                    tipo: cmd.Tipo,
                    nome: cmd.Nome,
                    apelido: cmd.Apelido,
                    cpfCnpj: cmd.CpfCnpj,
                    rg: cmd.Rg,
                    email: cmd.Email,
                    telefone: cmd.Telefone,
                    celular: cmd.Celular,
                    vagas: cmd.VagasContratadas
                );

                pro.AtualizaEndereco(endereco);

                propRepos.Update(pro);
                return new ResultadoAcao("Proprietário atualizado");
            }
            catch (Exception ex)
            {
                return new ResultadoAcao(ex);
            }
        }

        private static EnderecoDTO ObterEndereco(AtualizarProprietario cmd)
        {
            return new EnderecoDTO(
                                cep: cmd.Cep,
                                logradouro: cmd.Logradouro,
                                numero: cmd.Numero,
                                bairro: cmd.Bairro,
                                complemento: cmd.Complemento,
                                municipio: cmd.Municipio,
                                uF: cmd.UF
                            );
        }
    }
}
