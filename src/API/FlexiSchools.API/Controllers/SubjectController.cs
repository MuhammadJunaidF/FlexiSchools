using FlexiSchools.Application.Subjects;
using FlexiSchools.Application.Subjects.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlexiSchools.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService _subjectService;

        public SubjectController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        [HttpPost(nameof(Add))]
        public async Task<SaveSubjectResponseDto> Add(SubjectDto dto)
        {
            return await _subjectService.SaveAsync(dto);
        }

        [HttpPost(nameof(Get))]
        public async Task<List<SubjectDto>> Get()
        {
            return await _subjectService.GetAsync();
        }

    }
}
