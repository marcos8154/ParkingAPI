using Dapper;
using IoCdotNet;
using ParkingAPI.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ParkingAPI.Storage.Impl
{
    internal sealed class EstacionamentoRepositoryImpl : IEstacionamentoRepository
    {
        private readonly IDatabase db;
        public EstacionamentoRepositoryImpl()
        {
            db = IoC.Resolve<IDatabase>();
        }

        public Estacionamento Find(object id)
        {
            return db.Estacionamentos.Find(id);
        }

        public void Add(Estacionamento e)
        {
            db.Estacionamentos.Add(e);
            db.Commit();
        }

        public void Update(Estacionamento e)
        {
            db.Estacionamentos.Update(e);
            db.Commit();
        }

        public void Remove(Estacionamento e)
        {
            db.Estacionamentos.Remove(e);
            db.Commit();
        }

        public IReadOnlyCollection<Estacionamento> Where(Expression<Func<Estacionamento, bool>> query)
        {
            return db.Estacionamentos
                .Where(query)
                .ToList()
                .AsReadOnly();
        }

        public IReadOnlyCollection<Estacionamento> Where(string sql, object param)
        {
            return db
                .GetDbConnection()
                .Query<Estacionamento>(sql, param)
                .ToList()
                .AsReadOnly();
        }
    }
}
