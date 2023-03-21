using Business.Abstract;
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

        IBrandDal _BrandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _BrandDal = brandDal;
        }

        public List<Brand> GetAll()
        {
            return _BrandDal.GetAll();
        }

        public Brand GetById(int id)
        {
            return _BrandDal.Get(c => c.BrandId == id);
        }
    }
}
