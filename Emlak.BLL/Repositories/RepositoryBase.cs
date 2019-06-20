using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emlak.DAL.Context;



namespace Emlak.BLL.Repositories
{
    public abstract class RepositoryBase<T, ID> : IRepository<T, ID> where T : class
    {
        protected internal static EmlakContext db;

        public List<T> GetAll()
        {
            db = new EmlakContext();
            return db.Set<T>().ToList();
        }

        public T GetByID(ID id)
        {
            db = new EmlakContext();
            return db.Set<T>().Find(id);
        }

        public int Insert(T entity)
        {
            db = db ?? new EmlakContext();
            db.Set<T>().Add(entity);
            return db.SaveChanges();
        }

        public int Delete(T entity)
        {
            db = db ?? new EmlakContext();
            db.Set<T>().Remove(entity);
            return db.SaveChanges();
        }

        public int Update(T entity)
        {

            db = db ?? new EmlakContext();


            
            db.Set<T>().Attach(entity); //attach

            db.Entry(entity).State = EntityState.Modified;
            return db.SaveChanges(); 
            
        }
    }
}
