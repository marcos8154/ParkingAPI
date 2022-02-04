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
        public string Nome { get; set; }
        public string Apelido { get; set; }
        public TipoProprietario Tipo { get; set; }
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

            if (Tipo == TipoProprietario.PessoaFisica && CpfCnpj.Length != 11)
                throw new Exception("Para o tipo pessoa física, informe o CPF");
            else if (Tipo == TipoProprietario.PessoaJuridica && CpfCnpj.Length != 14)
                throw new Exception("Para o tipo pessoa jurídica, informe o CNPJ");
        }
    }
}
