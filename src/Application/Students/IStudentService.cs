using FlexiSchools.Application.Students.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexiSchools.Application.Students
{
    public interface IStudentService
    {
        Task<SaveStudentResponseDto> SaveAsync(StudentDto request); 
        Task<List<StudentDto>> GetAsync();
        Task<EnrollmentResponseDto> EnrollAsync(EnrollmentRequestDto request);
    }
}
