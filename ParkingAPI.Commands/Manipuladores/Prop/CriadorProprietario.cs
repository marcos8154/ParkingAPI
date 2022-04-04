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
    internal sealed class CriadorProprietario : ManipuladorComando<CriarProprietario>
    {
        private readonly IProprietarioRepository propRepos;
        public CriadorProprietario()
        {
            propRepos = IoC.Resolve<IProprietarioRepository>();
        }

        protected override ResultadoAcao ManipulaComando(CriarProprietario cmd)
        {
            try
            {
                cmd.Valida();

                EnderecoDTO endereco = new EnderecoDTO(
                    cep: cmd.Cep,
                    logradouro: cmd.Logradouro,
                    numero: cmd.Numero,
                    bairro: cmd.Bairro,
                    complemento: cmd.Complemento,
                    municipio: cmd.Municipio,
                    uF: cmd.UF
                );

                Proprietario pro = new Proprietario(
                    tipo: cmd.GetTipoPessoa(), 
                    nome: cmd.Nome, 
                    apelido: cmd.Apelido,
                    cpfCnpj: cmd.CpfCnpj,
                    rg: cmd.Rg,
                    email: cmd.Email,
                    telefone: cmd.Telefone,
                    celular: cmd.Celular,
                    vagas: cmd.VagasContratadas,
                    endereco: endereco
                );

                propRepos.Add(pro);
                return new ResultadoAcao("Proprietário adicionado");
            }
            catch (Exception ex)
            {
                return new ResultadoAcao(ex);
            }
        }
    }
}
