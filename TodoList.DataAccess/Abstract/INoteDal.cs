using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Core.DataAccess;
using TodoList.Entities.Concrete;
using TodoList.Entities.DTOs;

namespace TodoList.DataAccess.Abstract
{
    public interface INoteDal:IEntityRepository<Note>
    {
        public List<NoteDetailDto> GetNoteDetails();
    }
}
