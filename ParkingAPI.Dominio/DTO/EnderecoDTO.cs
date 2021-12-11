using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingAPI.Dominio.DTO
{
    public sealed class EnderecoDTO
    {
        public int Numero { get; private set; }
        public string Complemento { get; private set; }
        public string Bairro { get; private set; }
        public string Municipio { get; private set; }
        public string UF { get; private set; }

        public EnderecoDTO(int numero, string complemento, string bairro, string municipio, string uF)
        {
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Municipio = municipio;
            UF = uF;
        }
    }
}
