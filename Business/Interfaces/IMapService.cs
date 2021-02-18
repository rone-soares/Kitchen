namespace Business.Interfaces
{
    public interface IMapService<TEntity, TRequest>
        where TEntity : class
        where TRequest : class
    {
        TEntity MapEntity(TRequest request);
    }
}
