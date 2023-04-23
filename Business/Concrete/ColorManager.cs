using Business.Abstract;
using Business.Constant;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        readonly IColorDal _IColorDal;

        public ColorManager()
        {
        }

        public ColorManager(IColorDal ıColordal)
        {
            _IColorDal = ıColordal;
        }

        [ValidationAspect(typeof(ColorValidator))]
        public IResult Add(Color Color)
        {

            _IColorDal.Add(Color);
            return new SuccessResult("Added");
        }

        public IDataResult<Color> Get(int id)
        {
            return new SuccessDataResult<Color>(_IColorDal.Get(c => c.ColorId == id));
        }

        public IResult Update(Color Color)
        {
            _IColorDal.Update(Color);
            return new SuccessResult(Messages.Updated);
        }

        public IDataResult<List<Color>> GetAll()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Color>>(Messages.MainteNanceTime);
            }
            return new SuccessDataResult<List<Color>>(_IColorDal.GetAll(), Messages.ProductListed);
        }

        public IResult Delete(int id)
        {
            var result = _IColorDal.Get(c=>c.ColorId== id);
            if(result == null)
            {
                return new ErrorResult("Renk Bulunamadı");
            }
            _IColorDal.Delete(result);
            return new SuccessResult();
        }
    }
   
}
