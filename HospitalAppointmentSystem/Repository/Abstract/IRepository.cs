namespace HospitalAppointmentSystem.Repository.Abstract
{
    public interface IRepository<T, TKey> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(TKey id);
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(TKey id);
    }

}
