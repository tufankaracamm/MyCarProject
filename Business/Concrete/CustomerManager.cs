using Business.Abstract;
using Business.Constant;
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
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IResult Add(Customer Customer)
        {
            _customerDal.Add(Customer);
            return new SuccessResult();
        }

        public IResult Delete(int id)
        {
            var result = _customerDal.Get(c=> c.Id == id);
            if(result == null)
            {
                return new ErrorResult("Kullanıcı Bulunamadı");
            }
            _customerDal.Delete(result);
            return new SuccessResult();
        }

        public IDataResult<Customer> Get(int id)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(c => c.Id == id));
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(), Messages.ProductListed);
        }

        public IResult Update(Customer Customer)
        {
            throw new NotImplementedException();
        }
    }
}
