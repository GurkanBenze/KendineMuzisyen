using KendineMuzisyen.Business.Abstract;
using KendineMuzisyen.DataAccess.Abstract;
using KendineMuzisyen.Entity.Dtos.Musician;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KendineMuzisyen.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicianController : ControllerBase
    {
        private readonly IMusicianService _musicianService;

        public MusicianController(IMusicianService musicianService)
        {
            _musicianService = musicianService;
        }

        //endpoint - api
        [HttpGet("getById")]
        public IActionResult GetById(int userId)
        {
            var result = _musicianService.GetByFilter(x => x.Id == userId);
            return Ok(result);
        }

        //endpoint - api
        [HttpGet("getlist")]
        public IActionResult GetList()
        {
            var result = _musicianService.GetList();
            return Ok(result);
        }

        [HttpPut("update")]
        public IActionResult Update(MusicianRequestDto musicianRequestDto)
        {
            var result = _musicianService.Update(musicianRequestDto);
            return Ok(result);
        }

        [HttpDelete("remove")]
        public IActionResult Remove(int musicianId)
        {
            var result = _musicianService.Remove(musicianId);
            return Ok(result);
        }
    }
}
