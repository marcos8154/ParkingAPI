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
        public int Vagas { get; private set; }
        public int VagasSendoUsadas { get; private set; }
        public virtual List<Placa> Placas { get; private set; }
        public virtual List<Estadia> EstadiasAbertas { get; private set; }


        private Proprietario()
        {
            Placas = new List<Placa>();
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

            Nome = nome;
            Apelido = apelido;
            Tipo = tipo;
            CpfCnpj = cpfCnpj;
            Rg = rg;
            Vagas = vagas;

            AtualizaInfoContato(email, telefone, celular);
            AtualizaEndereco(endereco);

            Placas = new List<Placa>();
        }

        private void AtualizaInfoContato(string email, string telefone, string celular)
        {
            Email = email;
            Telefone = telefone;
            Celular = celular;
        }

        private void AtualizaEndereco(EnderecoDTO endereco)
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
