using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingAPI.Dominio
{
    public class Placa
    {
        public Guid Id { get; private set; }
        public string Descricao { get; private set; }
        public Boolean Padrao { get; private set; }

        public Placa(string descricao, Boolean padrao)
        {
            Id = Guid.NewGuid();

            if (string.IsNullOrEmpty(descricao))
                throw new Exception("A descrição é obrigátória");

            Descricao = descricao;
            Padrao = padrao;
        }

        public void DefineProprietario(Proprietario proprietario)
        {
            if (proprietario == null) ProprietarioId = null;
            else ProprietarioId = proprietario.Id;
        }

        public Guid? ProprietarioId { get; private set; }
        public virtual Proprietario Proprietario { get; private set; }
    }
}
