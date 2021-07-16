using Core.Entities;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IServiceRepository<T>
        where T: IEntity, new()
    {
        IResult Add(T t);
        IResult Delete(T t);
        IResult Update(T t);
        IDataResult<List<T>> GetAll();
    }
}
