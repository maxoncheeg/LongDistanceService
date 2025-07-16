namespace LongDistanceService.Data.Contexts.Abstract;

public interface IDbContext
{
    public Task CreateAsync<TEntity>(TEntity entity) where TEntity : class;
    public Task CreateRangeAsync<TEntity>(IList<TEntity> entities) where TEntity : class;
    public void Update<TEntity>(TEntity entity) where TEntity : class;
    public void Delete<TEntity>(TEntity entity) where TEntity : class;
    public void DeleteRange<TEntity>(IList<TEntity> entities) where TEntity : class;
    public Task SaveAsync();
    public IQueryable<IList<object>> SqlQuery(string query);
    public int ExecuteSql(string query);
}