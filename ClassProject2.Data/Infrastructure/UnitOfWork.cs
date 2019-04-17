
namespace ClassProject2.Data.Infrastructure
{
    /// <summary>
    /// Pattern keeps track of everything that happens during a business transaction that affects the database. 
    /// At the conclusion of the transaction, it determines how to update the database to conform to the changes.
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbFactory _dbFactory;
        private DataContext _dbContext;

        public UnitOfWork(IDbFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public DataContext DbContext
        {
            get { return _dbContext ?? (_dbContext = _dbFactory.Init()); }
        }

        public void Commit()
        {
            DbContext.Commit();
        }
    }
}
