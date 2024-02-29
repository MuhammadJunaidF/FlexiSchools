using FlexiSchools.Application.Lectures;
using FlexiSchools.Application.Lectures.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlexiSchools.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LectureController : ControllerBase
    {
        private readonly ILectureService _lectureService;

        public LectureController(ILectureService lectureService)
        {
            _lectureService = lectureService;
        }

        [HttpPost(nameof(Add))]
        public async Task<SaveLectureResponseDto> Add(LectureDto dto)
        {
            return await _lectureService.SaveAsyn(dto);
        }

        [HttpPost(nameof(Get))]
        public async Task<List<LectureDto>> Get()
        {
            return await _lectureService.GetAsync();
        }
    }
}
