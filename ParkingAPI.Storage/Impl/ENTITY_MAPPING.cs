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
        }

        private static void MapCobranca(ModelBuilder mb)
        {
            var em = mb.Entity<Cobranca>();
            em.HasKey(c => c.Id);
            em.HasOne(c => c.Placa);
            em.Property(c => c.CodigoCobranca).HasMaxLength(18).IsRequired();
            em.Property(c => c.Id).HasMaxLength(50);
            em.Property(c => c.PlacaId).HasMaxLength(50).IsRequired();
            em.Property(c => c.Descricao).HasMaxLength(180).IsRequired();
            em.Property(c => c.Valor).HasPrecision(10, 2);
        }
    }
}
