using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Core.Utilities.Results.Abstract;

namespace TodoList.Core.Utilities.Results.Concrete
{
    public class SuccessResult:Result
    {
        public SuccessResult(string message) : base(true, message) { }

        public SuccessResult() : base(true) { }
    }
}
