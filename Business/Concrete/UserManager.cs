using Business.Abstract;
using Business.Constant;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        readonly IUserDal _IUserDal;

        public UserManager()
        {
        }

        public UserManager(IUserDal ıUserdal)
        {
            _IUserDal = ıUserdal;
        }

        public IResult Add(User User)
        {

            _IUserDal.Add(User);
            return new SuccessResult("Added");
        }

        public IResult Delete(int id)
        {
            var result = _IUserDal.Get(u=>u.Id == id);
            if(result ==null)
            {
                return new ErrorResult("Kullanıcı bulunamadı");
            }
            _IUserDal.Delete(result);
            return new SuccessResult();
        }

        public IDataResult<User> Get(int id)
        {
            return new SuccessDataResult<User>(_IUserDal.Get(c => c.Id == id));
        }

        public IResult Update(User User)
        {
            _IUserDal.Update(User);
            return new SuccessResult(Messages.Updated);
        }

        public IDataResult<List<User>> GetAll()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<User>>(Messages.MainteNanceTime);
            }
            return new SuccessDataResult<List<User>>(_IUserDal.GetAll(), Messages.ProductListed);
        }
    }
}
