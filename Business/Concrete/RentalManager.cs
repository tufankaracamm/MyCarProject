using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental Rental)
        {
            _rentalDal.Add(Rental);
            return new SuccessResult();
        }

        public IResult Delete(int id)
        {
            var result = _rentalDal.Get(r => r.Id == id);
            if(result == null)
            {
                return new ErrorResult();
            }
            _rentalDal.Delete(result);
            return new SuccessResult();

        }


        public IDataResult<List<Rental>> GetAll()
        {
            _rentalDal.GetAll();
            return new SuccessDataResult<List<Rental>>();
        }

        public IResult Update(Rental Rental)
        {
            _rentalDal.Update(Rental);
            return new SuccessResult();
        }

        public IDataResult<Rental> Get(int id)
        {
     
            return new SuccessDataResult<Rental>(_rentalDal.Get(c => c.Id == id));
        }
    }
}
