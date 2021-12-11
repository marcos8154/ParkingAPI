using Microsoft.EntityFrameworkCore;
using ParkingAPI.Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingAPI.Storage.support
{
    public class FakeMySqlDatabase : IDatabase
    {
        public DbSet<Estacionamento> Estacionamentos { get; set; }
        public DbSet<Estadia> Estadias { get; set; }
        public DbSet<Placa> Placas { get; set; }
        public DbSet<Proprietario> Proprietarios { get; set; }
        public DbSet<Cobranca> Cobrancas { get; set; }

        public FakeMySqlDatabase()
        {
            Estacionamentos = new FakeDbSet<Estacionamento>();
            Estadias = new FakeDbSet<Estadia>();
            Placas = new FakeDbSet<Placa>();
            Proprietarios = new FakeDbSet<Proprietario>();
            Cobrancas = new FakeDbSet<Cobranca>();
        }

        public void Commit()
        {
        }

        public void ApplyPendingMigrations()
        {
        }

        public IDbConnection GetDbConnection()
        {
            throw new NotImplementedException();
        }
    }
}
