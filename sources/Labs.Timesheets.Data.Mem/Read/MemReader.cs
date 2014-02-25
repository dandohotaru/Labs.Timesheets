using System.Data.Entity;
using System.Linq;
using Labs.Timesheets.Reports.Common;
using Labs.Timesheets.Reports.Entities;

namespace Labs.Timesheets.Data.Mem.Read
{
    public class MemReader : DbContext, IReader
    {
        static MemReader()
        {
            Database.SetInitializer(new NullDatabaseInitializer<MemReader>());
        }

        public MemReader()
            : base("Name=MemContext")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public IDbSet<Activity> Activities { get; set; }

        public IDbSet<Customer> Customers { get; set; }

        public IDbSet<Tag> Tags { get; set; }

        public IQueryable<TEntity> Query<TEntity>() where TEntity : class, IEntity
        {
            return Set<TEntity>();
        }
    }
}