using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IResult Rent(Rental rental);
        IResult Cancel(Rental rental);
        IResult Update(Rental rental);
        IDataResult<List<Rental>> GetAll();
    }
}
