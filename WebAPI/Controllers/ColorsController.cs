using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : ControllerBase
    {
        IColorService _colorService;
        public ColorsController(IColorService colorService)
        {
            _colorService=colorService;
        }

        [HttpGet("getallcolor")]
        public IActionResult GetAllColor()
        {
            var result = _colorService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("getbyidcolor")]
        public IActionResult GetByIdColor(int id)
        {
            var result = _colorService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("addcolor")]
        public IActionResult AddColor(Color color)
        {
            var result = _colorService.AddColor(color);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("updatecolor")]
        public IActionResult UpdateColor(Color color)
        {
            var result = _colorService.UpdateColor(color);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
    }
}
