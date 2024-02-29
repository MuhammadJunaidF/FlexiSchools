using FlexiSchools.Application.LectureTheatres.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexiSchools.Application.LectureTheatres
{
    public interface ILectureTheatreService
    {
        Task<SaveTheatreResponseDto> SaveAsync(LectureTheatreDto request);
        Task<List<LectureTheatreDto>> GetAsync();
    }
}
