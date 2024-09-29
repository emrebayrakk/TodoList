using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Core.Entities.Abstract;

namespace TodoList.Entities.DTOs
{
    public class NoteDetailDto :IDto
    {
        public int TaskId { get; set; }
        public string UserName { get; set; }
        public string TaskTitle { get; set; }
        public string TaskDescription { get; set; }
        public DateTime TaskEndDate { get; set; }
    }
}
