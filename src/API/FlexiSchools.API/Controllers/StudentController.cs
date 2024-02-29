using FlexiSchools.Application.Students;
using FlexiSchools.Application.Students.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlexiSchools.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpPost(nameof(Add))]
        public async Task<SaveStudentResponseDto> Add(StudentDto dto)
        {
            return await _studentService.SaveAsync(dto);
        }

        [HttpPost(nameof(Get))]
        public async Task<List<StudentDto>> Get()
        {
            return await _studentService.GetAsync();
        }

        [HttpPost(nameof(Enroll))]
        public async Task<EnrollmentResponseDto> Enroll(EnrollmentRequestDto dto)
        {
            return await _studentService.EnrollAsync(dto);
        }
    }
}
