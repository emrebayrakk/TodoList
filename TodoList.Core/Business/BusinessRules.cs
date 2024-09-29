using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Core.Utilities.Results.Abstract;

namespace TodoList.Core.Business
{
    public class BusinessRules
    {
        public static IResult Run(params IResult[] logics)
        {
            foreach (var result in logics)
            {
                if (!result.Success)
                {
                    return result;
                }
            }

            return null;
        }
    }
}
