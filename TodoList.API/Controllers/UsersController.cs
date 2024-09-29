using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList.Business.Abstract;
using TodoList.Entities.Concrete;
using TodoList.Entities.DTOs;

namespace TodoList.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        [AllowAnonymous]
        [HttpGet("getall")]
        public IActionResult GetAllUser()
        {
            var result = _userService.GetAll();
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("useradd")]
        public IActionResult UserAdd(User user)
        {
            var result = _userService.AddUser(user);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("userdelete")]
        public IActionResult UserDelete(User user)
        {
            var result = _userService.DeleteUser(user);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("userupdate")]
        public IActionResult UserUpdated(User user)
        {
            var result = _userService.UpdateUser(user);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("[action]")]
        public IActionResult Authenticate([FromBody] UserForLoginDto userForLoginDto)
        {
            var result = _userService.Authenticate(userForLoginDto);
            if (result != null)
                return Ok(result);
            return BadRequest();

        }

    }
}
