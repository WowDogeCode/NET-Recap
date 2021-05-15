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
    public class EfCarDal : ICarDal
    {
        public void Add(Car entity)
        {
            using (CarRentalDBContext context = new CarRentalDBContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }
        public void Delete(Car entity)
        {
            using (CarRentalDBContext context = new CarRentalDBContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
        public Car Get(Expression<Func<Car, bool>> expression)
        {
            using (CarRentalDBContext context = new CarRentalDBContext())
            {
                return context.Set<Car>().SingleOrDefault(expression);
            }
        }
        public void Update(Car entity)
        {
            using (CarRentalDBContext context = new CarRentalDBContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        List<Car> IEntityRepository<Car>.GetAll(Expression<Func<Car, bool>> expression)
        {
            using (CarRentalDBContext context = new CarRentalDBContext())
            {
                return expression == null
                    ? context.Set<Car>().ToList()
                    : context.Set<Car>().Where(expression).ToList();
            }
        }
    }
}
