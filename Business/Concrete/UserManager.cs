using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        [ValidationAspect(typeof(UserValidator))]
        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessfulResult(Messages<User>.Added);
        }
        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessfulResult(Messages<User>.Deleted);
        }
        public IDataResult<List<User>> GetAll()
        {
            return new SuccessfulDataResult<List<User>>(_userDal.GetAll());
        }

        [ValidationAspect(typeof(UserValidator))]
        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessfulResult(Messages<User>.Updated);
        }
    }
}
