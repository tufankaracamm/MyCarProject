using Business.Abstract;
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
    public class BrandManager : IBrandService
    {
        private IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult Add(Brand Brand)
        {
            _brandDal.Add(Brand);
            return new SuccessResult();
        }

        public IResult Delete(int id)
        {
            var result = _brandDal.Get(b => b.BrandId == id);
            if(result == null)
            {
                return new ErrorResult("Marka Bulunamadı");
            }
            _brandDal.Delete(result);
            return new SuccessResult();
        }

        public IDataResult<Brand> Get(int id)
        {
            var result = _brandDal.Get(b=> b.BrandId == id);
            return new SuccessDataResult<Brand>(result);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            var result = _brandDal.GetAll();  
            return new SuccessDataResult<List<Brand>>(result);
        }

        public IResult Update(Brand Brand)
        {
            _brandDal.Update(Brand);
            return new SuccessResult();
        }
    }
}
