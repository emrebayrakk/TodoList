using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Core.DataAccess.EntityFramework;
using TodoList.DataAccess.Abstract;
using TodoList.Entities.Concrete;

namespace TodoList.DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User,TodoListContext> , IUserDal
    {

    }
}
