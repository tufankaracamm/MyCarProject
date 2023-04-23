using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Core.Entities;
using ProductMiniApi.Repository.Abastract;
using Microsoft.AspNetCore.Rewrite;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImageController : ControllerBase
    {

        private readonly IFileService _fileService;
        private readonly ICarImageService _carImageService;
        public CarImageController(IFileService fileService, ICarImageService carImageService)
        {
            _fileService = fileService;
            _carImageService = carImageService;

        }

        [HttpGet("getall")]
        public IActionResult getall()
        {
            var result = _carImageService.GetAll();
            return result.Success ? Ok(result) : BadRequest();
        }

        [HttpPost("add")]
        public IActionResult add(CarImage carImage)
        {
            var result = _carImageService.Add(carImage);
            return result.Success ? Ok(result) : BadRequest();


        }

        [HttpPost("delete")]
        public IActionResult delete(int id)
        {
            var result = _carImageService.Delete(id);
            return result.Success ? Ok(result) : BadRequest();
        }
        [HttpPost("update")]
        public IActionResult update(CarImage carImage)
        {
            var result = _carImageService.Update(carImage);
            return result.Success ? Ok(result) : BadRequest();
        }
        [HttpGet("getid")]
        public IActionResult Get(int id)
        {
            var result = _carImageService.Get(id);
            return result.Success ? Ok(result) : BadRequest();
        }



        [HttpPost("deneme")]
        public IActionResult deneme([FromForm] AddCarImageDto addCarImageDto)
        {
            var status = new Status();
            
            if (addCarImageDto.IFormFile != null)
            {
                var fileResult = _fileService.SaveImage(addCarImageDto.IFormFile);
                if (fileResult.Item1 == 1)
                {
                    string fileName = fileResult.Item2; // getting name of image
                    var result = _carImageService.Add(new CarImage { CarId = addCarImageDto.CarId, ImagePath = fileResult.Item2, CreatedDate = DateTime.Now });
                    if (result.Success)
                    {
                        status.StatusCode = 1;
                        status.Message = "Added successfully";
                    }
                    return Ok(status);
                }
            }
            else
            {
                var result = _carImageService.Add(new CarImage { CarId = addCarImageDto.CarId, ImagePath = "Uploads\\defaultImage.jpg", CreatedDate = DateTime.Now });
                if (result.Success)
                {
                    status.StatusCode = 1;
                    status.Message = "Added successfully";
                    return Ok(status);
                }
            }
            status.StatusCode = 0;
            status.Message = "Error on adding product";
            return Ok(status);
        }
    }
}
