using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Core.DataAccess.EntityFramework;
using TodoList.DataAccess.Abstract;
using TodoList.Entities.Concrete;
using TodoList.Entities.DTOs;

namespace TodoList.DataAccess.Concrete.EntityFramework
{
    public class EfNoteDal:EfEntityRepositoryBase<Note,TodoListContext> , INoteDal
    {
        public List<NoteDetailDto> GetNoteDetails()
        {
            using var context = new TodoListContext();
            var result = from n in context.Notes
                         join u in context.Users
                         on n.UserId equals u.UserId
                         select new NoteDetailDto
                         {
                             TaskId = n.TaskId,
                             TaskTitle = n.TaskTitle,
                             TaskDescription = n.TaskDescription,
                             TaskEndDate = n.TaskEndDate,
                             UserName = u.UserName
                         };
            return result.ToList();
        }
    }
}
