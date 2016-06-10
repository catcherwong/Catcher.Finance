using System.Collections.Generic;

namespace Catcher.Finance.DataAccess
{
    public interface IBaseRepository<T> where T : class
    {
        IList<T> GetAll();
        bool Add(T entity);
        bool Update(T entity);
        bool Delete(T entity);
        bool DeleteById(object Id);
        T GetById(object Id);
    }
}
