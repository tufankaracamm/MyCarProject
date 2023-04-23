using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        private IBrandDal _brandDal;
        private IHttpContextAccessor _httpContextAccessor;

        public BrandManager(IBrandDal brandDal, IHttpContextAccessor httpContextAccessor)
        {
            _brandDal = brandDal;
            _httpContextAccessor = httpContextAccessor;
        }

        [ValidationAspect(typeof(BrandValidator))]
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

        [SecuredOperation("car.getall")]
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
