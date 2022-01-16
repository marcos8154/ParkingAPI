using ParkingAPI.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingAPI.Storage
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Usuario Login(string login, string senha);
        Usuario ObterLogin(string login);
    }
}
