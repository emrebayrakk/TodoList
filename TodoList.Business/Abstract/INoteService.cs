using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TodoList.Core.Utilities.Results.Abstract;
using TodoList.Entities.Concrete;
using TodoList.Entities.DTOs;

namespace TodoList.Business.Abstract
{
    public interface INoteService
    {
        IDataResult<List<Note>> GetAll();

        IDataResult<List<Note>> GetAllDayNote(DateTime dateTime);

        IDataResult<List<Note>> GetAllWeekNote(DateTime dateTime);
        IDataResult<List<Note>> GetAllMonthNote(DateTime dateTime);

        IDataResult<List<NoteDetailDto>> GetNoteDetails();
        IDataResult<Note> GetById(int noteId);
        IResult AddNote(Note note);
    }
}
