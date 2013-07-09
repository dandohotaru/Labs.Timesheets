using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Labs.Timesheets.Domain.Common.Adapters;
using Labs.Timesheets.Domain.Common.Entities;
using Labs.Timesheets.Domain.Tracking.Entities;

namespace Labs.Timesheets.Data.Efw.Contexts
{
    public class StorageAdapter : DbContext, IStorageAdapter
    {
        static StorageAdapter()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<StorageAdapter>());
        }

        public StorageAdapter()
            : base("Name=EntitiesContext")
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

        public TEntity Find<TEntity>(Guid id) where TEntity : class, IEntity
        {
            return Set<TEntity>().Find(id);
        }

        public void Add<TEntity>(TEntity entity) where TEntity : class, IEntity
        {
            Set<TEntity>().Add(entity);
        }

        public void Add<TEntity>(IEnumerable<TEntity> entities) where TEntity : class, IEntity
        {
            foreach (var entity in entities)
            {
                Set<TEntity>().Add(entity);
            }
        }

        public void Remove<TEntity>(TEntity entity) where TEntity : class, IEntity
        {
            Set<TEntity>().Remove(entity);
        }

        public void Remove<TEntity>(IEnumerable<TEntity> entities) where TEntity : class, IEntity
        {
            foreach (var entity in entities)
            {
                Set<TEntity>().Remove(entity);
            }
        }

        public void Save()
        {
            SaveChanges();
        }

        public void Clear()
        {
        }
    }
}