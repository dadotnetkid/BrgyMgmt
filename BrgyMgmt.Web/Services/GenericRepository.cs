using BrgyMgmt.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace BrgyMgmt.Web.Services {
    public class GenericRepository<TEntity> where TEntity : class {
        internal BrgyMgmtEntities context;
        internal DbSet<TEntity> dbSet;

        public GenericRepository(BrgyMgmtEntities context) {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "") {
            IQueryable<TEntity> query = dbSet;

            if (filter != null) {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)) {
                query = query.Include(includeProperty);
            }

            if (orderBy != null) {
                return orderBy(query).ToList();
                //return orderBy(query);
            }
            else {
                return query.ToList();
                //return query;
            }
        }
        public virtual IQueryable<TEntity> Fetch(string includeProperties = "") {
            IQueryable<TEntity> query = dbSet;

            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)) {
                query = query.Include(includeProperty);
            }

            return query;
        }

        public virtual TEntity GetByID(object id) {
            return dbSet.Find(id);
        }

        public virtual void Insert(TEntity entity) {
            dbSet.Add(entity);
        }

        public virtual void Delete(object id) {
            TEntity entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete) {
            if (context.Entry(entityToDelete).State == EntityState.Detached) {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

        public virtual void Update(TEntity entityToUpdate) {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }
    }

}