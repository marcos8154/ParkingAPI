using Microsoft.EntityFrameworkCore;
using ParkingAPI.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingAPI.Storage.Impl
{
    internal sealed class ENTITY_MAPPING
    {
        public static void MAP(ModelBuilder mb)
        {
            MapCobranca(mb);
            MapEstadia(mb);
            MapFormaPag(mb);
            MapPagamentoEst(mb);
        }

        private static void MapPagamentoEst(ModelBuilder mb)
        {
            var em = mb.Entity<PagamentoEstadia>();
            em.HasKey(e => e.Id);
            em.HasOne(e => e.FormaPagamento);
            em.HasOne(e => e.Cobranca);
            em.Property(c => c.ValorPagamento).HasPrecision(10, 2);
        }

        private static void MapFormaPag(ModelBuilder mb)
        {
            var em = mb.Entity<FormaPagamento>();
            em.HasKey(e => e.Id);
            em.Property(e => e.Nome)
                .IsRequired(true);

        }

        private static void MapEstadia(ModelBuilder mb)
        {
            var em = mb.Entity<Estadia>();
            em.HasKey(e => e.Id);
            em.Property(e => e.Id)
                .IsRequired(true);
            em.HasOne(e => e.Placa);
            em.HasOne(e => e.Estacionamento);
            em.Property(e => e.EstacionamentoId)
                .IsRequired(true);
            em.Property(e => e.PlacaId)
                .IsRequired(true);
            em.Property(e => e.DataEntrada)
                .IsRequired(true);
            em.Property(e => e.DataSaida)
                .IsRequired(false);
            em.Property(e => e.Observacao)
                            .IsRequired(false)
                            .HasMaxLength(250);
            em.Property(e => e.TempoConsumo)
                .IsRequired(false)
                .HasMaxLength(60)
                .HasDefaultValue(string.Empty);
        }

        private static void MapCobranca(ModelBuilder mb)
        {
            var em = mb.Entity<Cobranca>();
            em.HasKey(c => c.Id);
            em.HasOne(c => c.Placa);
            em.HasMany(c => c.Pagamentos)
                .WithOne(p => p.Cobranca);
            em.Property(c => c.CodigoCobranca).HasMaxLength(18).IsRequired();
            em.Property(c => c.Id).HasMaxLength(50);
            em.Property(c => c.PlacaId).HasMaxLength(50).IsRequired();
            em.Property(c => c.Descricao).HasMaxLength(180).IsRequired();
            em.Property(c => c.Valor).HasPrecision(10, 2);
        }
    }
}
