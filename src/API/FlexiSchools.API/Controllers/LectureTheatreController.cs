using FlexiSchools.Application.LectureTheatres;
using FlexiSchools.Application.LectureTheatres.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlexiSchools.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LectureTheatreController : ControllerBase
    {
        private readonly ILectureTheatreService _lectureTheatreService;

        public LectureTheatreController(ILectureTheatreService lectureTheatreService)
        {
            _lectureTheatreService = lectureTheatreService;
        }

        [HttpPost(nameof(Add))]
        public async Task<SaveTheatreResponseDto> Add(LectureTheatreDto dto)
        {
            return await _lectureTheatreService.SaveAsync(dto);
        }

        [HttpPost(nameof(Get))]
        public async Task<List<LectureTheatreDto>> Get()
        {
            return await _lectureTheatreService.GetAsync();
        }
    }
}
