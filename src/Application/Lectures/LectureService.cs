using FlexiSchools.Application.Common.Enums;
using FlexiSchools.Application.Common.Interfaces;
using FlexiSchools.Application.Lectures.DTOs;
using FlexiSchools.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexiSchools.Application.Lectures
{
    public class LectureService : ILectureService
    {
        private readonly IFlexiSchoolsDbContext _context;
        private readonly ILogger<LectureService> _logger;

        public LectureService(IFlexiSchoolsDbContext context, ILogger<LectureService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<List<LectureDto>> GetAsync()
        {
            return await _context.Lectures.Include(s => s.Subject).Include(t => t.LectureTheatre).Select(l => new LectureDto()
            {
                Id = l.Id,
                Subject = l.Subject.Name,
                LectureTheatre = l.LectureTheatre.Name,
                DayOfWeek = l.DayOfWeek,
                DurationInMinutes = l.DurationInMinutes,    
                StartTime = l.StartTime
            }).ToListAsync();
        }

        public async Task<SaveLectureResponseDto> SaveAsyn(LectureDto request)
        {
            var response = new SaveLectureResponseDto();
            try
            {
                var isNewLecture = request.Id == 0;
                var lecture = isNewLecture ? new Lecture() : await _context.Lectures.Include(s => s.Subject).Include(t => t.LectureTheatre).FirstOrDefaultAsync(r => r.Id == request.Id);
              
                if (lecture == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Lecture not found.";
                    response.StatusCode = StatusCodes.NotFound;
                    return response;
                }

                var subject = await _context.Subjects.FirstOrDefaultAsync(x => x.Name.ToLower() == request.Subject.ToLower());
                if (subject == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Subject not found.";
                    response.StatusCode = StatusCodes.NotFound;
                    return response;
                }

                var lectureTheatre = await _context.LectureTheatres.FirstOrDefaultAsync(x => x.Name.ToLower() == request.Subject.ToLower());
                if (lectureTheatre == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Lecture theatre not found.";
                    response.StatusCode = StatusCodes.NotFound;
                    return response;
                }

                if (isNewLecture)
                {
                    lecture.CreationTime = DateTime.UtcNow;
                    _context.Lectures.Add(lecture);
                }
                else
                {
                    lecture.LastModificationTime = DateTime.UtcNow;
                    _context.Lectures.Update(lecture);
                }


                lecture.SubjectId = subject.Id;
                lecture.LectureTheatreId = lectureTheatre.Id;
                lecture.DayOfWeek = request.DayOfWeek;
                lecture.StartTime = request.StartTime;
                lecture.DurationInMinutes = request.DurationInMinutes;


                if (await _context.SaveChangesAsync() > 0)
                {
                    response.IsSuccess = true;
                    response.Message = lecture.Id.ToString();
                    response.StatusCode = StatusCodes.Success;
                }

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.StatusCode = StatusCodes.InternalServerError;
                response.Message = ex.Message;
                _logger.LogError($"Error while saving lecture info: {ex}");
            }

            return response;
        }
    }
}
