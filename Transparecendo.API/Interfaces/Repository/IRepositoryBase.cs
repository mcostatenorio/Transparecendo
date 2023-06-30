namespace Transparecendo.Service.API.Interfaces.Repository
{
    public interface IRepositoryBase<T> where T : class
    {
        void Add(T obj);
        void AddList(List<T> obj);

        void Update(T obj);

        void Remove(T obj);

        IEnumerable<T> GetAll();

        T GetById(int Id);
    }
}
