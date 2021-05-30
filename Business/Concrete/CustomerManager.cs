using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;
        CustomerValidator customerValidator = new CustomerValidator();
        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }
        public IResult Add(Customer customer)
        {
            var result = customerValidator.Validate(customer);
            if(result.IsValid == true)
            {
                _customerDal.Add(customer);
                return new SuccessfulResult(Messages<Customer>.Added);
            }
            return new ErrorResult();
        }

        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessfulResult(Messages<Customer>.Deleted);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessfulDataResult<List<Customer>>(_customerDal.GetAll());
        }

        public IResult Update(Customer customer)
        {
            var result = customerValidator.Validate(customer);
            if(result.IsValid == true)
            {
                _customerDal.Update(customer);
                return new SuccessfulResult(Messages<Customer>.Updated);
            }
            return new ErrorResult();
        }
    }
}
