using FlexiSchools.Application.Subjects.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexiSchools.Application.Subjects
{
    public interface ISubjectService
    {
        Task<SaveSubjectResponseDto> SaveAsync(SubjectDto request);
        Task<List<SubjectDto>> GetAsync();
    }
}
