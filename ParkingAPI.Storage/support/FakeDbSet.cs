using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ParkingAPI.Storage.support
{
    public class FakeDbSet<TEntity> : DbSet<TEntity> where TEntity : class
    {
        private List<TEntity> entries;
        public FakeDbSet()
        {
            entries = new List<TEntity>();
        }

        public override EntityEntry<TEntity> Add(TEntity entity)
        {
            entries.Add(entity);
            return new EntityEntry<TEntity>(null);
        }

        public override EntityEntry<TEntity> Update(TEntity entity)
        {
            object idValue = entity.GetType()
                .GetProperty("Id")
                .GetValue(entity);

            TEntity existing = entries
                .FirstOrDefault(e => e
                    .GetType()
                    .GetProperty("Id")
                    .GetValue(e) == idValue);

            if(existing != null)
            {
                foreach(PropertyInfo existingProp  in existing.GetType().GetProperties())
                {
                    try
                    {
                        object entityPropValue = entity.GetType()
                             .GetProperty(existingProp.Name, (BindingFlags.Public | BindingFlags.NonPublic))
                             .GetValue(entity);

                        existingProp.SetValue(existing, entityPropValue);
                    }
                    catch { }
                }
            }

            return new EntityEntry<TEntity>(null);
        }
    
        public override EntityEntry<TEntity> Remove(TEntity entity)
        {
            object idValue = entity.GetType()
                .GetProperty("Id")
                .GetValue(entity);

            TEntity existing = entries
                .FirstOrDefault(e => e
                .GetType()
                .GetProperty("Id")
                .GetValue(e) == idValue);

            if (existing != null)
                entries.Remove(existing);

            return new EntityEntry<TEntity>(null);
        }

        public override TEntity Find(params object[] keyValues)
        {
            if (keyValues == null) return null;
            if (keyValues.Length == 0) return null;

            object keyValue = keyValues[0];

            TEntity existing = entries
                .FirstOrDefault(e => e
                .GetType()
                .GetProperty("Id")
                .GetValue(e) == keyValue);

            return existing;
        }
    }
}
