using ParkingAPI.Dominio.DTO;
using ParkingAPI.Dominio.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingAPI.Dominio
{
    public class Proprietario
    {
        public Guid Id { get; private set; }
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
        public virtual List<Placa> Placas { get; private set; }

        private Proprietario()
        {

        }

        public Proprietario(
            TipoProprietario tipo,
            string nome,
            string apelido,
            string cpfCnpj,
            string rg,
            string email,
            string telefone,
            string celular,
            int vagas,
            EnderecoDTO endereco)
        {
            Id = Guid.NewGuid();

            if (string.IsNullOrEmpty(nome))
                throw new Exception("O nome é obrigátório");

            if (string.IsNullOrEmpty(apelido))
                throw new Exception("O apelido é obrigátório");

            if (string.IsNullOrEmpty(cpfCnpj))
                throw new Exception("O CPF / CNPJ é obrigátório");

            if (tipo == TipoProprietario.PessoaFisica && cpfCnpj.Length != 11)
            {
                throw new Exception("Para o tipo pessoa física, informe o CPF");
            }
            else if (tipo == TipoProprietario.PessoaJuridica && cpfCnpj.Length != 14)
            {
                throw new Exception("Para o tipo pessoa jurídica, informe o CNPJ");
            }

            AtualizaInfo(tipo, nome, apelido, cpfCnpj, rg, email, telefone, celular, vagas);
            AtualizaEndereco(endereco);

            Placas = new List<Placa>();
        }

        public void AtualizaInfo(
            TipoProprietario tipo,
            string nome,
            string apelido,
            string cpfCnpj,
            string rg,
            string email,
            string telefone,
            string celular,
            int vagas)
        {
            if (string.IsNullOrEmpty(nome))
                throw new Exception("O nome é obrigátório");

            if (string.IsNullOrEmpty(apelido))
                throw new Exception("O apelido é obrigátório");

            if (string.IsNullOrEmpty(cpfCnpj))
                throw new Exception("O CPF / CNPJ é obrigátório");

            if (tipo == TipoProprietario.PessoaFisica && cpfCnpj.Length != 11)
            {
                throw new Exception("Para o tipo pessoa física, informe o CPF");
            }
            else if (tipo == TipoProprietario.PessoaJuridica && cpfCnpj.Length != 14)
            {
                throw new Exception("Para o tipo pessoa jurídica, informe o CNPJ");
            }

            Nome = nome;
            Apelido = apelido;
            Tipo = tipo;
            CpfCnpj = cpfCnpj;
            Rg = rg;
            VagasContratadas = vagas;

            AtualizaInfoContato(email, telefone, celular);
        }

        private void AtualizaInfoContato(string email, string telefone, string celular)
        {
            Email = email;
            Telefone = telefone;
            Celular = celular;
        }

        public void AtualizaEndereco(EnderecoDTO endereco)
        {
            Cep = endereco.Cep;
            Logradouro = endereco.Logradouro;
            Numero = endereco.Numero;
            Complemento = endereco.Complemento;
            Bairro = endereco.Bairro;
            Municipio = endereco.Municipio;
            UF = endereco.UF;
        }

        public void AdicionaPlaca(Placa placa)
        {
            placa.DefineProprietario(this);
            Placas.Add(placa);
        }
    }
}
