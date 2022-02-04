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
    internal sealed class EstadiaRepos : IEstadiaRepository
    {
        private IDatabase db;

        public EstadiaRepos()
        {
            db = IoC.Resolve<IDatabase>();
        }

        public Estadia ObterEstadiaAbertaPorPlaca(string placa)
        {
            return db.Estadias.FirstOrDefault(e =>
                e.PlacaId.Equals(placa) &&
                e.Encerrado());
        }

        public IReadOnlyCollection<Estadia> ObterEstadiaPorPlaca(string placa)
        {
            return db.Estadias.Where(e => e.PlacaId.Equals(placa))
                .ToList();
        }

        public IReadOnlyCollection<Estadia> ObterEstadiaAberta()
        {
            return db.Estadias.Where(e => e.DataSaida == null).ToList();
        }

        public IReadOnlyCollection<Estadia> ObterEstadiaPorEstacionamento(string cnpj_estacionamento)
        {
            return db.Estadias.Where(e => e.Estacionamento.CNPJ.Equals(cnpj_estacionamento))
                .ToList();
        }

        public Estadia Find(object id)
        {
            return db.Estadias.Find(id);
        }

        public void Add(Estadia e)
        {
            db.Estadias.Add(e);
            db.Commit();
        }

        public void Update(Estadia e)
        {
            db.Estadias.Update(e);
            db.Commit();
        }

        public void Remove(Estadia e)
        {
            db.Estadias.Remove(e);
            db.Commit();
        }

        public IReadOnlyCollection<Estadia> Where(Expression<Func<Estadia, bool>> query)
        {
            return db.Estadias.Where(query).ToList();
        }

        public IReadOnlyCollection<Estadia> Where(string sql, object param)
        {
            using (IDbConnection conn = db.GetDbConnection())
                return conn.Query<Estadia>(sql, param).ToList();
        }

        private int VagasEmConsumo(Proprietario proprietario, TipoEstadia tipo)
        {
            return db.Estadias
                .Where(e => proprietario.Id.Equals(e.Placa.ProprietarioId) &&
                       e.Tipo == tipo)
                .Count();
        }

        public bool PossuiDisponibilidade(Proprietario donoPlaca)
        {
            int vagasEmConsumo = VagasEmConsumo(donoPlaca, TipoEstadia.Mensalista);
            return (vagasEmConsumo < donoPlaca.VagasContratadas);
        }

        public Estadia ObterEstadiaPlacaNaoPrioritaria(Proprietario donoPlaca)
        {
            return db.Estadias
                 .Where(e => e.Placa.PlacaPrioritaria == false && donoPlaca.Id.Equals(e.Placa.ProprietarioId))
                 .FirstOrDefault();
        }
    }
}
