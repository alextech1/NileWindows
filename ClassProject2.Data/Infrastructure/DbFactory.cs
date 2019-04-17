
namespace ClassProject2.Data.Infrastructure
{
    /// <summary>
    /// Return single instanse DataContext
    /// </summary>
    public class DbFactory : Disposable, IDbFactory
    {
        DataContext _dbContext;

        public DataContext Init()
        {
            return _dbContext ?? (_dbContext = new DataContext());
        }

        protected override void DisposeCore()
        {
            if (_dbContext != null)
                _dbContext.Dispose();
        }
    }
}
