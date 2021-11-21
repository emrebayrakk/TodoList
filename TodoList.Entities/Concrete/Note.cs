using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Core.Entities.Abstract;

namespace TodoList.Entities.Concrete
{
    public class Note : IEntity
    {
        public int TaskId { get; set; }
        public int UserId { get; set; }
        public string TaskTitle { get; set; }
        public string TaskDescription { get; set; }
        public DateTime TaskStartDate { get; set; }
        public DateTime TaskEndDate { get; set; }
        public bool Status { get; set; }
    }
}
