using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingAPI.Dominio
{
    public class Placa
    {
        public string Id { get; private set; }
        public string Descricao { get; private set; }

        public Placa(string placa, string descricao)
        {
            Id = placa;
            Descricao = descricao;
        }

        public Placa()
        {

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
