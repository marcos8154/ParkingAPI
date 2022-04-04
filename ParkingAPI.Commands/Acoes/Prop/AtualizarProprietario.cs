using ParkingAPI.Commands.Manipuladores.Prop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkingAPI.Dominio.Enum;

namespace ParkingAPI.Commands.Acoes.Prop
{
    public class AtualizarProprietario : IComandoAPI
    {
        public string Id { get; set; }
        public string Nome { get; private set; }
        public string Apelido { get; private set; }
        public TipoPessoa Tipo { get; private set; }
        public string CpfCnpj { get; private set; }
        public string Rg { get; private set; }
        public string Cep { get; private set; }
        public int Numero { get; private set; }
        public string Complemento { get; private set; }
        public string Logradouro { get; private set; }
        public string Bairro { get; private set; }
        public string Municipio { get; private set; }
        public string UF { get; private set; }
        public string Email { get; private set; }
        public string Telefone { get; private set; }
        public string Celular { get; private set; }
        public int VagasContratadas { get; private set; }

        public  async Task<IResultadoAcao> Executar()
        {
            return await new AtualizadorProprietario().Manipular(this);
        }

        public void Valida()
        {
            if (string.IsNullOrEmpty(Id))
                throw new Exception("Para atualizar, é obrigatório informar o Id");

            if (string.IsNullOrEmpty(Nome))
                throw new Exception("O nome é obrigátório");

            if (string.IsNullOrEmpty(Apelido))
                throw new Exception("O apelido é obrigátório");

            if (string.IsNullOrEmpty(CpfCnpj))
                throw new Exception("O CPF / CNPJ é obrigátório");

            if (Tipo == TipoPessoa.PessoaFisica && CpfCnpj.Length != 11)
            {
                throw new Exception("Para o tipo pessoa física, informe o CPF");
            }
            else if (Tipo == TipoPessoa.PessoaJuridica && CpfCnpj.Length != 14)
            {
                throw new Exception("Para o tipo pessoa jurídica, informe o CNPJ");
            }
        }
    }
}
