using Microsoft.EntityFrameworkCore;
using ParkingAPI.Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingAPI.Storage
{
    public interface IDatabase
    {
        DbSet<Estacionamento> Estacionamentos { get; set; }
        DbSet<Estadia> Estadias { get; set; }
        DbSet<Placa> Placas { get; set; }
        DbSet<Proprietario> Proprietarios { get; set; }
        DbSet<Cobranca> Cobrancas { get; set; }
        DbSet<PagamentoEstadia> Pagamentos { get; set; }
        DbSet<Usuario> Usuarios { get; set; }
        DbSet<FormaPagamento> FormasPagamento { get; set; }
     

        void Commit();

        void ApplyPendingMigrations();
        IDbConnection GetDbConnection();
    }
}
