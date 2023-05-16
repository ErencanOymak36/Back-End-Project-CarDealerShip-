using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        ICarImageService _carImageService;
        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
            
        }

        [HttpGet("getallimages")]
        public IActionResult GetAll() 
        {
        
            var result=_carImageService.GetAll();
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost("addimage")]
        public IActionResult AddImage(CarImage image)
        {
            var result=_carImageService.Add(image);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest();

        }

        [HttpPost("Delete")]
        public IActionResult DeleteImage(CarImage carImage)
        {
            var result=_carImageService.Delete(carImage);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost("updateimage")]
        public IActionResult UpdateImage(CarImage image)
        {
            var result= _carImageService.Update(image);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }


    }
}
