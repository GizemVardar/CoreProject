using Demo.Core.DAL.Concrete;
using Demo.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Demo.Core.DAL.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity> : IEntityRepository<TEntity> where TEntity : class, IEntity, new()
    {
        //readonly sadece okunabilir bir nesne olarak kullandık northwind context i 
        private readonly NorthwindContext _northwindContext;
        public EfEntityRepositoryBase(NorthwindContext northwindContext)
        {
            _northwindContext = northwindContext;
        }

        public void Add(TEntity entity)
        {
            var addedEntity = _northwindContext.Entry(entity);
            addedEntity.State = EntityState.Added;
            _northwindContext.SaveChanges();

        }

        public void Delete(TEntity entity)
        {
            var deletedEntity = _northwindContext.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
             _northwindContext.SaveChanges();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter = null)
        {
            // filtreye göre ürün yada kategori getirecek metottur singleordefault tek olarak getir yoksa default neyse onu getir. 
            return _northwindContext.Set<TEntity>().SingleOrDefault(filter);
        }

        public List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {

            return filter ==null
                ?_northwindContext.Set<TEntity>().ToList() // filtre yoksa hepsini list et
                :_northwindContext.Set<TEntity>().Where(filter).ToList(); // filtre varsa onu getir.

        }

        public void Update(TEntity entity)
        {

            var updatedEntity = _northwindContext.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            _northwindContext.SaveChanges();
        }
    }
}
