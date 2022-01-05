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
        public string Nome { get; private set; }
        public string Apelido { get; private set; }
        public TipoProprietario Tipo { get; private set; }
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
            {
                throw new Exception("Para o tipo pessoa física, informe o CPF");
            }
            else if (Tipo == TipoProprietario.PessoaJuridica && CpfCnpj.Length != 14)
            {
                throw new Exception("Para o tipo pessoa jurídica, informe o CNPJ");
            }
        }
    }
}
