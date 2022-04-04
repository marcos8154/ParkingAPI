using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace ParkingAPI.Dominio
{
    public class Usuario
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Login { get; private set; }
        public string Senha { get; private set; }

        static void Main()
        {

        }

        public static string CalculaHash(string Senha)
        {
            try
            {
                System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(Senha);
                byte[] hash = md5.ComputeHash(inputBytes);
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                for (int i = 0; i < hash.Length; i++)
                {
                    sb.Append(hash[i].ToString("X2"));
                }
                return sb.ToString(); 
            }
            catch (Exception)
            {
                return null; 
            }
        }

        private Usuario()
        {

        }

        public Usuario(string nome, string login, string senha)
        {
            Id = Guid.NewGuid();

            if (string.IsNullOrEmpty(nome))
                throw new Exception("O nome é obrigátório");

            if (string.IsNullOrEmpty(login))
                throw new Exception("O login é obrigátório");

            if (string.IsNullOrEmpty(senha))
                throw new Exception("A senha é obrigátório");

            AtualizaInfo(nome, login, senha); 
        }

        public void AtualizaInfo(string nome, string login, string senha)
        {
            Nome = nome;
            Login = login;
            Senha = CalculaHash(senha);
        }
    }
}
