namespace LongDistanceService.Data.Contexts;

public interface IDbContext
{
    public void Create<TEntity>(TEntity entity) where TEntity : class;
    public void Update<TEntity>(TEntity entity) where TEntity : class;
    public void Delete<TEntity>(TEntity entity) where TEntity : class;
    public Task SaveAsync();
}