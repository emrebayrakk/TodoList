using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TodoList.Business.Abstract;
using TodoList.Core.Business;
using TodoList.Core.Utilities.Results.Abstract;
using TodoList.Core.Utilities.Results.Concrete;
using TodoList.DataAccess.Abstract;
using TodoList.Entities.Concrete;
using TodoList.Entities.DTOs;

namespace TodoList.Business.Concrete
{
    public class NoteManager : INoteService
    {
        private readonly INoteDal _noteDal;

        public NoteManager(INoteDal noteDal)
        {
            _noteDal = noteDal;
        }
        public IDataResult<List<Note>> GetAll()
        {
            return new SuccessDataResult<List<Note>>(_noteDal.GetAll().ToList());
        }

        public IDataResult<List<Note>> GetAllDayNote(DateTime dateTime)
        {
            var result = _noteDal.GetAll(g => g.TaskEndDate == DateTime.Now || g.TaskStartDate == DateTime.Now).ToList();

            if (result.Count == 0)
            {
                return new ErrorDataResult<List<Note>>("günlük görev bulunamadı");
            }

            return new SuccessDataResult<List<Note>>(result);
        }

        public IDataResult<List<Note>> GetAllWeekNote(DateTime dateTime)
        {
            var result = _noteDal.GetAll(g =>
                g.TaskEndDate == DateTime.Now.AddDays(7) || g.TaskStartDate == DateTime.Now.AddDays(-7)).ToList();

            if (result.Count==0)
            {
                return new ErrorDataResult<List<Note>>("haftalık görev bulunamadı");
            }

            return new SuccessDataResult<List<Note>>(result);
        }

        public IDataResult<List<Note>> GetAllMonthNote(DateTime dateTime)
        {
            var result = _noteDal.GetAll(g =>
                g.TaskEndDate == DateTime.Now.AddMonths(1) || g.TaskStartDate == DateTime.Now.AddMonths(-1)).ToList();

            if (result.Count == 0)
            {
                return new ErrorDataResult<List<Note>>("aylık görev bulunamadı");
            }

            return new SuccessDataResult<List<Note>>(result);
        }

        public IDataResult<List<NoteDetailDto>> GetNoteDetails()
        {
            throw new NotImplementedException();
        }

        public IDataResult<Note> GetById(int noteId)
        {
            throw new NotImplementedException();
        }

        public IResult AddNote(Note note)
        {
            _noteDal.Add(note);
            return new SuccessResult("görev eklendi");
        }
    }
}
