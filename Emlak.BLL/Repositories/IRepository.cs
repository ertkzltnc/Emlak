using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emlak.BLL.Repositories
{
    public interface IRepository<T, ID> where T : class
    {
        List<T> GetAll();
        T GetByID(ID id);
        int Insert(T entity);
        int Delete(T entity);
        int Update(T entity);


    }
}
