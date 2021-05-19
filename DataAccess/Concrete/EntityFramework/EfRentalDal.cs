using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, CarRentalDBContext>, IRentalDal
    {
        public override Rental GetById(Expression<Func<Rental, bool>> expression)
        {
            using (CarRentalDBContext context = new CarRentalDBContext())
            {
                return context.Set<Rental>().Where(expression).OrderByDescending(r => r.ReturnDate)?.First();
            }
        }
    }
}
