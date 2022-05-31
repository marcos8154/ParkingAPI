using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingAPI.Dominio
{
    public class FormaPagamento
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public bool Inativo { get; set; }

        public FormaPagamento(string nome)
        {
            Id = Guid.NewGuid();
            Atualizar(nome);
        }



        public FormaPagamento() { }


        public void Atualizar(string nome, bool inativo = false)
        {
            if (string.IsNullOrEmpty(nome))
                throw new Exception("Defina um nome para a forma de pagamento");
            if (nome.Length < 3)
                throw new Exception("O nome deve ter no mínimo 3 caracteres");

            Nome = nome;
            Inativo = inativo;
        }

    }
}
