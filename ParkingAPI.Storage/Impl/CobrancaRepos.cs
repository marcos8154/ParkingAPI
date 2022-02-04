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
    internal sealed class CobrancaRepos : ICobrancaRepository
    {
        private readonly IDatabase db;

        public CobrancaRepos()
        {
            db = IoC.Resolve<IDatabase>();
        }

        public Cobranca Find(object id)
        {
            return db.Cobrancas.Find(id);
        }

        public void Add(Cobranca e)
        {
            db.Cobrancas.Add(e);
            db.Commit();
        }

        public void Update(Cobranca e)
        {
            db.Cobrancas.Update(e);
            db.Commit();
        }

        public void Remove(Cobranca e)
        {
            db.Cobrancas.Remove(e);
            db.Commit();
        }

        public IReadOnlyCollection<Cobranca> Where(Expression<Func<Cobranca, bool>> query)
        {
            return db.Cobrancas.Where(query)
                  .ToList();
        }

        public IReadOnlyCollection<Cobranca> Where(string sql, object param)
        {
            using (IDbConnection conn = db.GetDbConnection())
                return conn.Query<Cobranca>(sql, param).ToList();
        }
    }
}
