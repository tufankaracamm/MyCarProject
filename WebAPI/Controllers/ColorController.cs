using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorController : ControllerBase
    {
        IColorService _colorService;

        public ColorController(IColorService colorService)
        {
            _colorService = colorService;
        }

        [HttpGet("getall")]
        public IActionResult Get()
        {
            var result = _colorService.GetAll();
            return result.Success ? Ok(result) : BadRequest();
        }
        [HttpGet("getid")]
        public IActionResult getid(int id)
        {
            var result = _colorService.Get(id);
            return result.Success ? Ok(result) : BadRequest();
        }
        [HttpPost("add")]
        public IActionResult add(Color color)
        {
            var result = _colorService.Add(color);
            return result.Success ? Ok(result) : BadRequest();
        }
        [HttpPost("delete")]
        public IActionResult Delete(int id)
        {
            var result = _colorService.Delete(id);
            return result.Success ? Ok(result) : BadRequest();
        }

        [HttpPost("update")]
        public IActionResult update(Color color)
        {
            var result = _colorService.Update(color);
            return result.Success ? Ok(result) : BadRequest();

        }


    }
}
