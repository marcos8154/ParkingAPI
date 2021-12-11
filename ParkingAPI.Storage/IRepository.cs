using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ParkingAPI.Storage
{
    public interface IRepository <TEntity> where TEntity : class
    {
        TEntity Find(object id);
        void Add(TEntity e);
        void Update(TEntity e);
        void Remove(TEntity e);
        IReadOnlyCollection<TEntity> Where(Expression<Func<TEntity, bool>> query);
        IReadOnlyCollection<TEntity> Where(string sql, object param);
    }
}
