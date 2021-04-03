namespace DemoDI.Cases
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public void Adicionar(T obj)
        {
            // Faz algo
        }
    }
}
