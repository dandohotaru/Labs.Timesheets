using System.Data.Entity;
using System.Linq;
using Labs.Timesheets.Reports.Common;
using Labs.Timesheets.Reports.Entities;

namespace Labs.Timesheets.Data.Sql.Read
{
    public class SqlReader : DbContext, IReader
    {
        static SqlReader()
        {
            Database.SetInitializer(new NullDatabaseInitializer<SqlReader>());
        }

        public SqlReader()
            : base("Name=SqlContext")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public IDbSet<Activity> Activities { get; set; }

        public IDbSet<Customer> Customers { get; set; }

        public IDbSet<Tag> Tags { get; set; }

        public IQueryable<TEntity> Query<TEntity>() where TEntity : class, IEntity
        {
            return Set<TEntity>().AsNoTracking();
        }
    }
}