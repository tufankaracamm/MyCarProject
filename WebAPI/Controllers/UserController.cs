using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet("getall")]
        public IActionResult getall() 
        {
            var result = _userService.GetAll();
            return result.Success ? Ok(result) : BadRequest();
        }
        [HttpGet("getid")]
        public IActionResult getid(int id) 
        {
            var result = _userService.Get(id);
            return result.Success ? Ok(result) : BadRequest();
        }
        [HttpPost("add")]
        public IActionResult add(User user) 
        {
            var result = _userService.Add(user);
            return result.Success ? Ok(result) : BadRequest();
        }
        [HttpPost("update")]
        public IActionResult update(User user) 
        {
            var result = _userService.Update(user);
            return result.Success ? Ok(result) : BadRequest();
        }
        [HttpPost("delete")]
        public IActionResult delete(int id) 
        {
            var result = _userService.Delete(id);
            return result.Success ? Ok(result) : BadRequest();
        }

    }
}
