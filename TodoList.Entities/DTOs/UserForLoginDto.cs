using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Core.Entities.Abstract;

namespace TodoList.Entities.DTOs
{
    public class UserForLoginDto : IDto
    {
        public string UserName { get; set; }
        public string UserPassword { get; set; }
    }
}
