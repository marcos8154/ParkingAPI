using Dapper;
using IoCdotNet;
using Microsoft.EntityFrameworkCore;
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
    internal sealed class EstacionaRepos : IEstacionamentoRepository
    {
        private readonly IDatabase db;
        public EstacionaRepos()
        {
            db = IoC.Resolve<IDatabase>();
        }

        public Estacionamento ObterPorCnpj(string cnpj)
        {
            return db.Estacionamentos
                .FirstOrDefault(e => e.CNPJ.Equals(cnpj));
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

        public IQueryable<Estacionamento> Where(Expression<Func<Estacionamento, bool>> query)
        {
            return db.Estacionamentos.Where(query);
        }

        public IReadOnlyCollection<Estacionamento> Where(string sql, object param)
        {
            using (IDbConnection conn = db.GetDbConnection())
                return conn.Query<Estacionamento>(sql, param).ToList();
        }

        public IReadOnlyCollection<Estacionamento> Todos()
        {
            return db.Estacionamentos.AsNoTracking().ToList();
        }
    }
}
