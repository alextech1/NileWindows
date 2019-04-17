using ClassProject2.Data.Entities;
using System.Data.Entity;

namespace ClassProject2.Data
{
    public class DataContext : DbContext
    {
        public DataContext() : base("NileDatabase")
        {
            Database.SetInitializer<DataContext>(new DbContextInitializer());
        }
        
        public virtual void Commit()
        {
            SaveChanges();
        }

        #region DBSet
        public DbSet<Customer> CustomerSet { get; set; }
        public DbSet<Product> ProductSet { get; set; }
        public DbSet<Order> OrderSet { get; set; }
        public DbSet<LineItem> LineItemSet { get; set; }
        #endregion
                
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");
        }
    }

    public class DbContextInitializer : DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext db)
        {
            db.CustomerSet.Add(new Customer()
            { 
                FirstName = "Bob",
                LastName = "Miller"
            });
            db.CustomerSet.Add(new Customer()
            {                
                FirstName = "Sue",
                LastName = "Storm"
            });
            db.CustomerSet.Add(new Customer()
            {
                FirstName = "Peter",
                LastName = "Parker"
            });
            db.SaveChanges();
        }
    }
}
