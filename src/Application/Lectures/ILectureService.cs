using FlexiSchools.Application.Lectures.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexiSchools.Application.Lectures
{
    public interface ILectureService
    {
        Task<SaveLectureResponseDto> SaveAsyn(LectureDto request);
        Task<List<LectureDto>> GetAsync();
    }
}
