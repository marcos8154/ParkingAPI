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
            foreach (PagamentoEstadia pag in e.Pagamentos)
            {
                if (db.Pagamentos.Find(pag.Id) == null)
                    db.Pagamentos.Add(pag);
            }


            db.Cobrancas.Update(e);
            db.Commit();
        }

        public void Remove(Cobranca e)
        {
            db.Cobrancas.Remove(e);
            db.Commit();
        }

        public IQueryable<Cobranca> Where(Expression<Func<Cobranca, bool>> query)
        {
            return db.Cobrancas.Where(query);
        }

        public IReadOnlyCollection<Cobranca> Where(string sql, object param)
        {
            using (IDbConnection conn = db.GetDbConnection())
                return conn.Query<Cobranca>(sql, param).ToList();
        }

        public Cobranca ObterPorCodigo(string codigoCobranca)
        {
            return db.Cobrancas
                 .Include(c => c.Estadia)
                 .Include(c => c.Placa)
                     .ThenInclude(p => p.Proprietario)
                 .Include(c => c.Pagamentos)
                    .ThenInclude(p => p.Cobranca)
                 .FirstOrDefault(c => c.CodigoCobranca.Equals(codigoCobranca));

        }
    }
}
