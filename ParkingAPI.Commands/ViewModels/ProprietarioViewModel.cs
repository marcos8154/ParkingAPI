using ParkingAPI.Dominio;
using ParkingAPI.Dominio.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingAPI.Commands.ViewModels
{
    public class ProprietarioViewModel
    {
        public ProprietarioViewModel()
        {

        }

        public ProprietarioViewModel(Proprietario p)
        {
            Nome = p.Nome;
            Apelido = p.Apelido;
            TipoPessoaProprietario = p.Tipo == TipoPessoa.PessoaFisica ? "PF" : "PJ";
            CpfCnpj = p.CpfCnpj;
            Rg = p.Rg;
            Cep = p.Cep;
            Numero = p.Numero;
            Complemento = p.Complemento;
            Logradouro = p.Logradouro;
            Bairro = p.Bairro;
            Municipio = p.Municipio;
            UF = p.UF;
            Email = p.Email;
            Telefone = p.Telefone;
            Celular = p.Celular;
            VagasContratadas = p.VagasContratadas;

            Placas = new List<PlacaViewModel>();
            if (p.Placas != null)
                p.Placas.ForEach(pl => Placas.Add(new PlacaViewModel(Nome, pl.Id, pl.DescricaoVeiculo, pl.PlacaPrioritaria)));
        }

        public string Nome { get;  set; }
        public string Apelido { get;  set; }
        public string TipoPessoaProprietario { get;  set; }
        public string CpfCnpj { get;  set; }
        public string Rg { get;  set; }
        public string Cep { get;  set; }
        public int Numero { get;  set; }
        public string Complemento { get;  set; }
        public string Logradouro { get;  set; }
        public string Bairro { get;  set; }
        public string Municipio { get;  set; }
        public string UF { get;  set; }
        public string Email { get;  set; }
        public string Telefone { get;  set; }
        public string Celular { get;  set; }
        public int VagasContratadas { get;  set; }
        public List<PlacaViewModel> Placas { get;  set; }
    }
}
