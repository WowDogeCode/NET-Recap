using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;
        BrandValidator brandValidator = new BrandValidator();

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }
        public IResult Add(Brand brand)
        {
            var result = brandValidator.Validate(brand);
            if(result.IsValid == true)
            {
                _brandDal.Add(brand);
                return new SuccessfulResult();
            }
            return new ErrorResult();
        }
        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessfulResult();
        }
        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessfulDataResult<List<Brand>>(_brandDal.GetAll());
        }
        public IDataResult<Brand> GetById(int brandId)
        {
            return new SuccessfulDataResult<Brand>(_brandDal.GetById(b => b.BrandId == brandId));
        }
        public IResult Update(Brand brand)
        {
            var result = brandValidator.Validate(brand);
            if(result.IsValid == true)
            {
                _brandDal.Update(brand);
                return new SuccessfulResult();
            }
            return new ErrorResult();
        }
    }
}
