using Transparecendo.Core.Services;
using Transparecendo.Service.API.Interfaces.Repository;
using Transparecendo.Service.API.Interfaces.Services;

namespace Transparecendo.Service.API.Services
{
    public class ServiceBase<T> : BaseService, IServiceBase<T> where T : class
    {
        private readonly IRepositoryBase<T> _Repository;

        public ServiceBase(IRepositoryBase<T> repository)
        {
            _Repository = repository;
        }

        public void Add(T obj)
        {
            _Repository.Add(obj);
        }

        public Result GetAll()
        {
            return Success(_Repository.GetAll());
        }

        public T GetById(int Id)
        {
            return _Repository.GetById(Id);
        }

        public void Remove(T obj)
        {
            _Repository.Remove(obj);
        }

        public void Update(T obj)
        {
            _Repository.Update(obj);
        }
    }
}
