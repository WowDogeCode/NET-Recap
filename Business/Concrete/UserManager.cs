using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
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
        UserValidator userValidator = new UserValidator();
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public IResult Add(User user)
        {
            var result = userValidator.Validate(user);
            if(result.IsValid == true)
            {
                _userDal.Add(user);
                return new SuccessfulResult(Messages<User>.Added);
            }
            return new ErrorResult();
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
        public IResult Update(User user)
        {
            var result = userValidator.Validate(user);
            if(result.IsValid == true)
            {
                _userDal.Update(user);
                return new SuccessfulResult(Messages<User>.Updated);
            }
            return new ErrorResult();
        }
    }
}
