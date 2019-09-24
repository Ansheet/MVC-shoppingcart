using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingCart.DAL
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAllEntity();
        void AddEntity(T Entity);
        void DeleteEntity(object ID);
        void UpdateEntity(T Entity);
        void Save();
        T GetByID(object ID);
        IEnumerable<T> ShowEntityByPageIndex(object pageNo, object pageSize, object CurrentPage, Expression<Func<T, bool>> wherePredict, Expression<Func<T, int>> orderbypredict);
        IQueryable<T> GetAllByIQueryable();
        IEnumerable<T> spCall(string spName, object[] sqlparam);

    }
}
