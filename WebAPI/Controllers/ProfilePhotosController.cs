using Business.Abstract;
using Bussines.Abstract;
using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfilePhotosController : ControllerBase
    {
        IProfilePhotoService _profilePhotoService;
       
        public ProfilePhotosController(IProfilePhotoService profilePhotoService)
        {
            _profilePhotoService = profilePhotoService;
        }
        [HttpPost("add")]
        public IActionResult Add([FromForm] IFormFile file, [FromForm] ProfilePhoto profilePhoto)
        {
            var result = _profilePhotoService.Add(file, profilePhoto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(ProfilePhoto profilePhoto)
        {
            var result = _profilePhotoService.Delete(profilePhoto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update([FromForm] IFormFile file, [FromForm] ProfilePhoto profilePhoto)
        {
            var result = _profilePhotoService.Update(file, profilePhoto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _profilePhotoService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyuserid")]
        public IActionResult GetByUserId(int userId)
        {
            var result = _profilePhotoService.GetByUserId(userId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyimageid")]
        public IActionResult GetById(int imageId)
        {
            var result = _profilePhotoService.GetById(imageId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
