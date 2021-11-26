using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Core.Utilities.Results.Abstract;
using TodoList.Core.Utilities.Security.Token;
using TodoList.Entities.Concrete;
using TodoList.Entities.DTOs;

namespace TodoList.Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<User>> GetAll();
        IResult AddUser(User user);
        IResult DeleteUser(User user);
        IResult UpdateUser(User user);
        AccessToken Authenticate(UserForLoginDto userForLoginDto);
    }
}
