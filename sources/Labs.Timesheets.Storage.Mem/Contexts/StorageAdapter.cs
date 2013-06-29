using System;
using System.Collections.Generic;
using System.Linq;
using Labs.Timesheets.Domain.Common.Adapters;
using Labs.Timesheets.Domain.Common.Entities;
using Labs.Timesheets.Domain.Common.Exceptions;

namespace Labs.Timesheets.Storage.Mem.Contexts
{
    public class StorageAdapter : IStorageAdapter
    {
        public StorageAdapter()
        {
            Instance = new Dictionary<Guid, object>();
        }

        public IDictionary<Guid, object> Instance { get; set; }

        public IQueryable<TEntity> Query<TEntity>() where TEntity : class, IEntity
        {
            return Instance
                .Values.OfType<TEntity>()
                .AsQueryable();
        }

        public TEntity Find<TEntity>(Guid id) where TEntity : class, IEntity
        {
            return Instance.ContainsKey(id) ? Instance[id] as TEntity : null;
        }

        public void Add<TEntity>(TEntity entity) where TEntity : class, IEntity
        {
            if (Instance.ContainsKey(entity.Id))
                throw new StorageException("The provided {0} id ({1}) already exists in the data store.", typeof (TEntity).Name, entity.Id);
            Instance.Add(entity.Id, entity);
        }

        public void Add<TEntity>(IEnumerable<TEntity> entities) where TEntity : class, IEntity
        {
            foreach (var entity in entities)
            {
                Add(entity);
            }
        }

        public void Remove<TEntity>(TEntity entity) where TEntity : class, IEntity
        {
            if (!Instance.ContainsKey(entity.Id))
                throw new StorageException("The provided {0} id ({1}) does not exist in the data store.", typeof (TEntity).Name, entity.Id);
            Instance.Remove(entity.Id);
        }

        public void Remove<TEntity>(IEnumerable<TEntity> entities) where TEntity : class, IEntity
        {
            foreach (var entity in entities)
            {
                Remove(entity);
            }
        }

        public void Save()
        {
        }

        public void Dispose()
        {
        }
    }
}