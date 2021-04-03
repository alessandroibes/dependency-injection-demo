namespace DemoDI.Cases
{
    public interface IGenericRepository<T> where T : class
    {
        void Adicionar(T obj);
    }
}
