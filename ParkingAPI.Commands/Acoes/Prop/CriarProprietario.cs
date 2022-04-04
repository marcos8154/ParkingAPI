using ParkingAPI.Commands.Manipuladores.Prop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkingAPI.Dominio.Enum;

namespace ParkingAPI.Commands.Acoes.Prop
{
    public class CriarProprietario : IComandoAPI
    {
        public TipoPessoa GetTipoPessoa()
        {
            if (string.IsNullOrEmpty(TipoPessoaProprietario)) throw new Exception("TipoPessoaProprietario não foi informado");
            if (TipoPessoaProprietario.Equals("PF")) return TipoPessoa.PessoaFisica;
            if (TipoPessoaProprietario.Equals("PJ")) return TipoPessoa.PessoaJuridica;
            throw new Exception($"'{TipoPessoaProprietario}' não é um valor válido para TipoPessoaProprietario");
        }

        public string Nome { get; set; }
        public string Apelido { get; set; }
        public string TipoPessoaProprietario { get; set; }
        public string CpfCnpj { get; set; }
        public string Rg { get; set; }
        public string Cep { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Municipio { get; set; }
        public string UF { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public int VagasContratadas { get; set; }

        public async Task<IResultadoAcao> Executar()
        {
            return await new CriadorProprietario().Manipular(this);
        }

        public void Valida()
        {
            if (string.IsNullOrEmpty(Nome))
                throw new Exception("O nome é obrigátório");

            if (string.IsNullOrEmpty(Apelido))
                throw new Exception("O apelido é obrigátório");

            if (string.IsNullOrEmpty(CpfCnpj))
                throw new Exception("O CPF / CNPJ é obrigátório");

            switch (TipoPessoaProprietario)
            {
                case "PF":
                    if (CpfCnpj.Length != 11)
                        throw new Exception("Para o tipo pessoa física, informe o CPF");
                    break;

                case "PJ":
                    if (CpfCnpj.Length != 14)
                        throw new Exception("Para o tipo pessoa jurídica, informe o CNPJ");
                    break;

                default: throw new Exception("TipoPessoa não identificado. Valores aceitos são: PF ou PJ");
            }
        }
    }
}
