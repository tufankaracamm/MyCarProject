using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpGet("getid")]
        public IActionResult Get(int id)
        {
            var result = _customerService.Get(id);
            return result.Success ? Ok(result) : BadRequest();
        }
        [HttpGet("getall")] 
        public IActionResult getall() 
        {
            var result = _customerService.GetAll();
            return result.Success ? Ok(result) : BadRequest();
        }
        [HttpPost("add")]
        public IActionResult add(Customer customer)
        {
            var result = _customerService.Add(customer);
            return result.Success ? Ok(result) : BadRequest();
        }
        [HttpPost("delete")]
        public IActionResult delete(int id) 
        {
            var result = _customerService.Delete(id);
            return result.Success ? Ok(result) : BadRequest();
        }
        [HttpPost("update")]
        public IActionResult update(Customer customer)
        {
            var result = _customerService.Update(customer);
            return result.Success ? Ok(result) : BadRequest();
        }

    }
}
