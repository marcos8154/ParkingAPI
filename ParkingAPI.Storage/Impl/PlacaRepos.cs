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
    internal sealed class PlacaRepos : IPlacaRepository
    {
        private readonly IDatabase db;

        public PlacaRepos()
        {
            db = IoC.Resolve<IDatabase>();
        }

        public Placa Find(object id)
        {
            return db.Placas.Find(id);
        }

        public void Add(Placa e)
        {
            db.Placas.Add(e);
            db.Commit();
        }

        public void Update(Placa e)
        {
            db.Placas.Update(e);
            db.Commit();
        }

        public void Remove(Placa e)
        {
            db.Placas.Remove(e);
            db.Commit();
        }

        public IQueryable<Placa> Where(Expression<Func<Placa, bool>> query)
        {
            return db.Placas.Where(query);
        }

        public IReadOnlyCollection<Placa> Where(string sql, object param)
        {
            using (IDbConnection conn = db.GetDbConnection())
                return conn.Query<Placa>(sql, param).ToList();
        }

        public IReadOnlyCollection<Placa> ObterPorProprietario(string cpfCnpj)
        {
            return db.Placas.Where(p =>
                p.Proprietario.CpfCnpj.Equals(cpfCnpj)
            ).ToList();
        }
    }
}
