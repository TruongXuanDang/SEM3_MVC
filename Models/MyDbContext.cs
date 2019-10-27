using System.Data.Entity;

namespace T1807MVC.Models
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class MyDbContext:DbContext
    {
        public MyDbContext() : base("name=MyContext")
        {

        }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<MyDbContext>(null);
            base.OnModelCreating(modelBuilder);
        }
    }
}