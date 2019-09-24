using OnlineShoppingCart.DAL.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingCart.DAL
{
    public class Repository<T> : IRepository<T> where T : class
    {
        DbSet<T> _dSet;
        OnlineshoppingDBEntities _Context = null;
        public Repository(OnlineshoppingDBEntities db)
        {
            this._Context = db;
            _dSet = _Context.Set<T>();
        }
        public void AddEntity(T Entity)
        {
            _Context.Entry(Entity).State = EntityState.Added;
        }

        public void DeleteEntity(object ID)
        {
            T existing = _dSet.Find(ID);
            _dSet.Remove(existing);
        }

        public IQueryable<T> GetAllByIQueryable()
        {
            return _dSet;
        }

        public IEnumerable<T> GetAllEntity()
        {
            return _dSet.ToList();
        }

        public T GetByID(object ID)
        {
            return _dSet.Find(ID);
        }

        public void Save()
        {
            _Context.SaveChanges();
        }

        public IEnumerable<T> spCall(string spName, object[] sqlparam)
        {
            return _Context.Database.SqlQuery<T>(spName, sqlparam);
        }

        public IEnumerable<T> ShowEntityByPageIndex(object pageNo, object pageSize, object CurrentPage, Expression<Func<T, bool>> wherePredict, Expression<Func<T, int>> orderbypredict)
        {
            if (wherePredict != null)
                return _dSet.OrderBy(orderbypredict).Where(wherePredict).ToList();
            else
                return _dSet.OrderBy(orderbypredict).ToList();
        }

        public void UpdateEntity(T Entity)
        {
            _Context.Entry(Entity).State = EntityState.Modified;
        }
    }
}
