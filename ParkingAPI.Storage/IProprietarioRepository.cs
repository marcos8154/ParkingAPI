using ParkingAPI.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingAPI.Storage
{
    public interface IProprietarioRepository : IRepository<Proprietario>
    {
        Proprietario ObterPorCpfCnpj(string cpfCnpj);
        Proprietario ObterPorTipo(int tipo, string pesquisa);
    }
}
