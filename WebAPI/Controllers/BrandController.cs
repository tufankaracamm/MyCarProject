using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _brandService.GetAll();
            return result.Success ? Ok(result) : BadRequest();
        }

        [HttpPost("add")]
        public IActionResult add(Brand brand) 
        {
            var result = _brandService.Add(brand);
            return result.Success ? Ok (result) : BadRequest();
        }

        [HttpPost("delete")]
        public IActionResult delete(int id)
        {
            var result = _brandService.Delete(id);
            return result.Success ? Ok(result) : BadRequest();
        }

        [HttpPost("update")]
        public IActionResult update(Brand brand) 
        {
            var result = _brandService.Update(brand);
            return result.Success ? Ok(result) : BadRequest();
        }

        [HttpGet("getid")]
        public IActionResult Get(int id)
        {
            var result = _brandService.Get(id);
            return result.Success ? Ok(result) : BadRequest();
        }


    }
}
