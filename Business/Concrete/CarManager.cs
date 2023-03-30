using Business.Abstract;
using Business.Constant;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Managerlar oluşturulacak 
//Managerlar Düzeltilecek 


namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _IcarDal;

        public CarManager()
        {
        }

        public CarManager(ICarDal ıcardal)
        {
            _IcarDal = ıcardal;
        }

        public IResult Add(Car car)
        {
            if (car.CarName.Length < 2)
            {
                return new ErrorResult(Messages.CarNameInvalid);
            }
            _IcarDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        

        public IDataResult<Car> Get(int id)
        {
            return new SuccessDataResult<Car>(_IcarDal.Get(c => c.Id == id));
        }

        public IResult Update(Car car)
        {
            var result = _IcarDal.Get(c => c.Id == car.Id);
            if(result == null)
            {
                return new ErrorResult("Araba Bulunamadı");
            }
             _IcarDal.Update(car);
            return new SuccessResult(Messages.Updated);
        }

        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour == 21)
            {
                return new ErrorDataResult<List<Car>>(Messages.MainteNanceTime);
            }
            return new SuccessDataResult<List<Car>>(_IcarDal.GetAll(), Messages.ProductListed);
        }

        public IDataResult<List<Car>> GetByUnitPrice(decimal min, decimal max)
        {
           return new SuccessDataResult<List<Car>>( _IcarDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailDtos()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_IcarDal.GetCarDetailDtos()) ;
        }

        public IResult Delete(int id)
        {
            //delete ederken id al id yi getByid ile al dal daki delete e getbyid den gelen nesneyi ver
            var result = _IcarDal.Get(p => p.Id == id);
            if(result == null)
            {
                return new ErrorResult("Araba Bulunamadı");
            }
            _IcarDal.Delete(result);
            return new SuccessResult();
        }
    }
    
}
