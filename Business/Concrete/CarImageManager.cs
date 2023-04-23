using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        private ICarImageDal _carImageDal; 

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }
        public IResult Add(CarImage CarImage)
        {
            //bir arabanın maksimum 5 tane resmi olabilir
            //CarImage'den gelen CarId ile GetAll yapıp GetAll parametresine CarId verirsek bize arabanın fotograflarının oldugu liste döner
            //elde ettiğimiz listenin uzunlugunu kontrol edersek bu iş kuralını yapmış oluruz 
            var result = _carImageDal.GetAll(c => c.CarId == CarImage.CarId).Count();
            if(result >= 5)
            {
                return new ErrorResult("En fazla 5 resim olabilir");
            }           
            _carImageDal.Add(CarImage);
            return new SuccessResult();

        }    
        public IResult Delete(int id)
        {
            var result = _carImageDal.Get(c => c.Id == id);
            _carImageDal.Delete(result);
            return new SuccessResult();
        }

        public IDataResult<CarImage> Get(int id)
        {
            var result = _carImageDal.Get(c => c.Id == id);
            return new SuccessDataResult<CarImage>(result);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            var result = _carImageDal.GetAll();
            return new SuccessDataResult<List<CarImage>>(result);
        }

        public IResult Update(CarImage CarImage)
        {
            _carImageDal.Update(CarImage);
            return new SuccessResult();
        }
    }
}
