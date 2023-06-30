using Transparecendo.Core.Services;

namespace Transparecendo.Service.API.Interfaces.Services
{
    public interface IServiceBase<T> where T : class
    {
        void Add(T obj);

        void Update(T obj);

        void Remove(T obj);

        Result GetAll();

        T GetById(int Id);
    }
}
