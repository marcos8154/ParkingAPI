using IoCdotNet;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using MySqlConnector;
using ParkingAPI.Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingAPI.Storage.Impl
{
    public sealed class MySqlDatabase : DbContext, IDatabase
    {
        public DbSet<Estacionamento> Estacionamentos { get; set; }
        public DbSet<Estadia> Estadias { get; set; }
        public DbSet<Placa> Placas { get; set; }
        public DbSet<Proprietario> Proprietarios { get; set; }
        public DbSet<Cobranca> Cobrancas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        private readonly IDatabaseConfig cfg;
        private static ServerVersion serverVersion;

        public MySqlDatabase()
        {
            cfg = IoC.Resolve<IDatabaseConfig>();
            DetectServerVersion();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ENTITY_MAPPING.MAP(modelBuilder);
        }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {


            options.UseMySql(cfg.ConnectionString(), serverVersion)
                .UseLazyLoadingProxies();
        }

        public void ApplyPendingMigrations()
        {
         //      Database.EnsureCreated();
            if (Database.GetPendingMigrations().Count() > 0)
                Database.Migrate();
        }

        public void Commit()
        {
            SaveChanges();
        }

        public IDbConnection GetDbConnection()
        {
            MySqlConnection conn = new MySqlConnection(cfg.ConnectionString());
            conn.Open();
            return conn;
        }

        private void DetectServerVersion()
        {
            var cString = cfg.ConnectionString()
                .Replace("ParkingDB", "mysql");

            if (serverVersion == null)
                using (MySqlConnection conn = new MySqlConnection(cString))
                    serverVersion = ServerVersion.AutoDetect(conn);
        }

 
    }
}
