using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalContrroller : ControllerBase
    {
        IRentalService _rentalService;

        public RentalContrroller(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }
        [HttpGet("getall")]
        public IActionResult getall()
        {
            var result = _rentalService.GetAll();
            return result.Success ? Ok(result) : BadRequest();
        }
        [HttpGet("getid")]
        public IActionResult get(int id)
        {
            var result = _rentalService.Get(id);
            return result.Success ? Ok(result) : BadRequest();
        }
        [HttpPost("add")]
        public IActionResult add(Rental rental)
        {
            var result = _rentalService.Add(rental);
            return result.Success ? Ok(result) : BadRequest();
        }
        [HttpPost("update")]
        public IActionResult update(Rental rental) 
        {
            var result = _rentalService.Update(rental);
            return result.Success ? Ok(result) : BadRequest();
        }
        [HttpPost("delete")]
        public IActionResult delete(int id)
        {
            var result = _rentalService.Delete(id);
            return result.Success ? Ok(result) : BadRequest();
        }
    }
}
