using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBrandDal : IBrandDal
    {
        public void Add(Brand entity)
        {
            using (CarRentalDBContext context = new CarRentalDBContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }
        public void Delete(Brand entity)
        {
            using (CarRentalDBContext context = new CarRentalDBContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
        public List<Brand> GetAll(Expression<Func<Brand, bool>> expression = null)
        {
            using (CarRentalDBContext context = new CarRentalDBContext())
            {
                return expression == null
                    ? context.Set<Brand>().ToList()
                    : context.Set<Brand>().Where(expression).ToList();
            }
            
        }
        public void Update(Brand entity)
        {
            using (CarRentalDBContext context = new CarRentalDBContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
