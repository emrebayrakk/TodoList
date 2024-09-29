using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList.Business.Abstract;
using TodoList.Entities.Concrete;

namespace TodoList.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly INoteService _noteService;

        public NotesController(INoteService noteService)
        {
            _noteService = noteService;
        }

        [HttpGet("getlistall")]
        public IActionResult GetAllList()
        {
            var result = _noteService.GetAll();
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }
        [HttpGet("getdetailsall")]
        public IActionResult GetDetailsAll()
        {
            var result = _noteService.GetNoteDetails();
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);

        }
        [HttpGet("getlistday")]
        public IActionResult GetDayList()
        {
            var result = _noteService.GetAllDayNote();
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }
        [HttpGet("getlistweek")]
        public IActionResult GetWeekList()
        {
            var result = _noteService.GetAllWeekNote();
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }
        [HttpGet("getlistmonth")]
        public IActionResult GetMonthList()
        {
            var result = _noteService.GetAllMonthNote();
            if (result.Success)           
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int noteId)
        {
            var result = _noteService.GetById(noteId);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("add")]
        public IActionResult Add(Note note)
        {
            var result = _noteService.AddNote(note);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
                
        }

        [HttpPost("delete")]
        public IActionResult Delete(Note note)
        {
            var result = _noteService.DeleteNote(note);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("updated")]
        public IActionResult Update(Note note)
        {
            var result = _noteService.UpdateNote(note);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }
    }
}
