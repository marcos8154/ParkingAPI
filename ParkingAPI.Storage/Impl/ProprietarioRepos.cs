using Dapper;
using IoCdotNet;
using ParkingAPI.Dominio;
using ParkingAPI.Dominio.Enum;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ParkingAPI.Storage.Impl
{
    internal sealed class ProprietarioRepos : IProprietarioRepository
    {
        private readonly IDatabase db;

        public ProprietarioRepos()
        {
            db = IoC.Resolve<IDatabase>();
        }

        public Proprietario ObterPorCpfCnpj(string cpfCnpj)
        {
            return db.Proprietarios
                   .FirstOrDefault(p => p.CpfCnpj.Equals(cpfCnpj));
        }

        public Proprietario ObterPorTipo(int tipo, string pesquisa)
        {
            TipoProprietario tp = (TipoProprietario)tipo;
            return db.Proprietarios
                .FirstOrDefault(p =>
                    p.Tipo == tp &&
                    p.Nome.Contains(pesquisa));
        }

        public Proprietario Find(object id)
        {
            return db.Proprietarios.Find(id);
        }

        public void Add(Proprietario e)
        {
            db.Proprietarios.Add(e);
            db.Commit();
        }

        public void Update(Proprietario e)
        {
            db.Proprietarios.Update(e);
            db.Commit();
        }

        public void Remove(Proprietario e)
        {
            db.Proprietarios.Remove(e);
            db.Commit();
        }

        public IReadOnlyCollection<Proprietario> Where(Expression<Func<Proprietario, bool>> query)
        {
            return db.Proprietarios.Where(query)
                .ToList();
        }

        public IReadOnlyCollection<Proprietario> Where(string sql, object param)
        {
            using (IDbConnection conn = db.GetDbConnection())
                return conn.Query<Proprietario>(sql, param).ToList();
        }
    }
}
