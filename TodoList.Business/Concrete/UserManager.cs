using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Business.Abstract;
using TodoList.Core.Utilities.Results.Abstract;
using TodoList.Core.Utilities.Results.Concrete;
using TodoList.DataAccess.Abstract;
using TodoList.Entities.Concrete;

namespace TodoList.Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public IDataResult<List<User>> GetAll()
        {
            var result = _userDal.GetAll().ToList();
            if (result.Count==0)
            {
                return new ErrorDataResult<List<User>>("kullanıcı yok");
            }

            return new SuccessDataResult<List<User>>(result);
        }

        public IResult AddUser(User user)
        {
            _userDal.Add(user);
            return new SuccessResult("kullanıcı eklendi");
        }

        public IResult DeleteUser(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult("kullanıcı silindi");
        }

        public IResult UpdateUser(User user)
        {
            _userDal.Update(user);
            return new SuccessResult("kullanıcı güncellendi");
        }
    }
}
