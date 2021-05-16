using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }
        public IResult Add(Color color)
        {
            _colorDal.Add(color);
            return new SuccessfulResult();
        }
        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);
            return new SuccessfulResult();
        }
        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessfulDataResult<List<Color>>(_colorDal.GetAll());
        }
        public IDataResult<Color> GetById(int colorId)
        {
            return new SuccessfulDataResult<Color>(_colorDal.GetById(c => c.ColorId == colorId));
        }
        public IResult Update(Color color)
        {
            _colorDal.Update(color);
            return new SuccessfulResult();
        }
    }
}
