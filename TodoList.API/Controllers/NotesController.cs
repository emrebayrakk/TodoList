using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList.Business.Abstract;
using TodoList.Entities.Concrete;

namespace TodoList.API.Controllers
{
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
        [HttpGet("getlistday")]
        public IActionResult GetDayList(DateTime dateTime)
        {
            var result = _noteService.GetAllDayNote(dateTime);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }
        [HttpGet("getlistweek")]
        public IActionResult GetWeekList(DateTime dateTime)
        {
            var result = _noteService.GetAllDayNote(dateTime);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }
        [HttpGet("getlistmonth")]
        public IActionResult GetMonthList(DateTime dateTime)
        {
            var result = _noteService.GetAllDayNote(dateTime);
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
    }
}
