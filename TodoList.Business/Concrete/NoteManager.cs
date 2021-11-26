using System;
using System.Collections.Generic;
using System.Linq;
using TodoList.Business.Abstract;
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
        private readonly DateTime _dayNow = Convert.ToDateTime(DateTime.Now);
        public NoteManager(INoteDal noteDal)
        {
            _noteDal = noteDal;
        }
        public IDataResult<List<Note>> GetAll()
        {
            return new SuccessDataResult<List<Note>>(_noteDal.GetAll().ToList());
        }

        public IDataResult<List<Note>> GetAllDayNote()
        {
            var addDays = Convert.ToDateTime(DateTime.Now.AddDays(1));
            //var dayNow = Convert.ToDateTime(DateTime.Now);
            var result = _noteDal.GetAll(g => g.TaskEndDate <= addDays && g.TaskEndDate<=_dayNow)
               .ToList();

            if (result.Count==0)
            {
                return new ErrorDataResult<List<Note>>("günlük görev bulunamadı");
            }

            return new SuccessDataResult<List<Note>>(result);
        }

        public IDataResult<List<Note>> GetAllWeekNote()
        {
            var addWeeks = Convert.ToDateTime(DateTime.Now.AddDays(7));
            //var dayNow = Convert.ToDateTime(DateTime.Now);
            var result = _noteDal.GetAll(g => g.TaskStartDate <= _dayNow && g.TaskEndDate >= _dayNow && g.TaskEndDate<=addWeeks).ToList();

            if (result.Count == 0)
            {
                return new ErrorDataResult<List<Note>>("haftalık görev bulunamadı");
            }

            return new SuccessDataResult<List<Note>>(result);
        }

        public IDataResult<List<Note>> GetAllMonthNote()
        {
            var addMonths = Convert.ToDateTime(DateTime.Now.AddDays(30));
            var dayWeeks = Convert.ToDateTime(DateTime.Now.AddDays(7));
            //var dayNow = Convert.ToDateTime(DateTime.Now);
            var result = _noteDal.GetAll( g=> g.TaskStartDate <= _dayNow && g.TaskEndDate>=_dayNow && g.TaskEndDate<=addMonths && g.TaskEndDate> dayWeeks).ToList();

            if (result.Count == 0)
            {
                return new ErrorDataResult<List<Note>>("aylık görev bulunamadı");
            }

            return new SuccessDataResult<List<Note>>(result);
        }

        public IDataResult<List<NoteDetailDto>> GetNoteDetails()
        {
            return new SuccessDataResult<List<NoteDetailDto>>(_noteDal.GetNoteDetails(),"details");
        }

        public IDataResult<Note> GetById(int noteId)
        {
            var result = _noteDal.Get(p => p.TaskId == noteId);
            if (result==null)
            {
                return new ErrorDataResult<Note>("geçerli id giriniz");
            }
            return new SuccessDataResult<Note>(result);

        }

        public IResult AddNote(Note note)
        {
            _noteDal.Add(note);
            return new SuccessResult("görev eklendi");
        }

        public IResult DeleteNote(Note note)
        {
            _noteDal.Delete(note);
            return new SuccessResult("görev silindi");
        }

        public IResult UpdateNote(Note note)
        {
            _noteDal.Update(note);
            return new SuccessResult("görev güncellendi");
        }
    }
}
