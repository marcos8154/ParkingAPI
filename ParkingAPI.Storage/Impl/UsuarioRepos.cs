using Dapper;
using IoCdotNet;
using ParkingAPI.Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ParkingAPI.Storage.Impl
{
    internal sealed class UsuarioRepos : IUsuarioRepository
    {
        private readonly IDatabase db;

        public UsuarioRepos()
        {
            db = IoC.Resolve<IDatabase>();
        }

        public Usuario Login(string login, string senha)
        {
            string senhaComparar = Usuario.CalculaHash(senha);
            return db.Usuarios.FirstOrDefault(u =>
                u.Login.Equals(login) && 
                u.Senha.Equals(senhaComparar)
            );
        }

        public Usuario ObterLogin(string login)
        {
            return db.Usuarios.FirstOrDefault(u => u.Login.Equals(login));
        }

        public Usuario Find(object id)
        {
            return db.Usuarios.Find(id);
        }

        public void Add(Usuario e)
        {
            db.Usuarios.Add(e);
            db.Commit();
        }

        public void Update(Usuario e)
        {
            db.Usuarios.Update(e);
            db.Commit();
        }

        public void Remove(Usuario e)
        {
            db.Usuarios.Remove(e);
            db.Commit();
        }

        public IQueryable<Usuario> Where(Expression<Func<Usuario, bool>> query)
        {
            return db.Usuarios.Where(query);
        }

        public IReadOnlyCollection<Usuario> Where(string sql, object param)
        {
            using (IDbConnection cn = db.GetDbConnection())
                return cn.Query<Usuario>(sql, param).ToList();
        }
    }
}
