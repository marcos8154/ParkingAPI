using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingAPI.Commands.ViewModels
{
    public class LoginViewModel
    {
        public DateTime DataLogin { get; set; }
        public string Usuario { get; set; }
        public string Token { get; set; }

        public LoginViewModel()
        {
            DataLogin = DateTime.Now;
        }

        public LoginViewModel(string usuario, string token)
        {
            DataLogin = DateTime.Now;
            Usuario = usuario;
            Token = token;
        }
    }
}
