using Microsoft.EntityFrameworkCore;
using Transparecendo.Service.API.Infrastructure.DbContext;
using Transparecendo.Service.API.Interfaces.Repository;

namespace Transparecendo.Service.API.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly TransparecendoDbContext _transparecendoDbContext;

        public RepositoryBase(TransparecendoDbContext transparecendoDbContext)
        {
            _transparecendoDbContext = transparecendoDbContext;
        }

        public void Add(T obj)
        {
            try
            {
                _transparecendoDbContext.Set<T>().Add(obj);
                _transparecendoDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AddList(List<T> obj)
        {
            try
            {
                _transparecendoDbContext.Set<T>().AddRange(obj);
                _transparecendoDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<T> GetAll()
        {
            return _transparecendoDbContext.Set<T>().ToList();
        }

        public T GetById(int Id)
        {
            return _transparecendoDbContext.Set<T>().Find(Id);
        }

        public void Remove(T obj)
        {
            try
            {
                _transparecendoDbContext.Set<T>().Remove(obj);
                _transparecendoDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(T obj)
        {
            try
            {
                _transparecendoDbContext.Entry(obj).State = EntityState.Modified;
                _transparecendoDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
