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
    internal sealed class FormaPagtoReposImpl : IFormaPagamentoRepository
    {
        private readonly IDatabase db = null;
        public FormaPagtoReposImpl()
        {
            db = IoC.Resolve<IDatabase>();
        }

        public FormaPagamento Find(object id)
        {
            return db.FormasPagamento.Find(id);
        }

        public void Add(FormaPagamento e)
        {
            db.FormasPagamento.Add(e);
            db.Commit();
        }

        public void Update(FormaPagamento e)
        {
            db.FormasPagamento.Update(e);
            db.Commit();
        }

        public void Remove(FormaPagamento e)
        {
            db.FormasPagamento.Remove(e);
            db.Commit();
        }

        public IQueryable<FormaPagamento> Where(Expression<Func<FormaPagamento, bool>> query)
        {
            return db.FormasPagamento.Where(query);
        }

        public IReadOnlyCollection<FormaPagamento> Where(string sql, object param)
        {
            return db
                .GetDbConnection()
                .Query<FormaPagamento>(sql, param)
                .ToList();
        }
    }
}
