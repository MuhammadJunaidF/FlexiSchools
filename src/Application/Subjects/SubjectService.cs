using FlexiSchools.Application.Common.Enums;
using FlexiSchools.Application.Common.Interfaces;
using FlexiSchools.Application.Subjects.DTOs;
using FlexiSchools.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexiSchools.Application.Subjects
{
    public class SubjectService : ISubjectService
    {
        private readonly IFlexiSchoolsDbContext _context;
        private readonly ILogger<SubjectService> _logger;

        public SubjectService(IFlexiSchoolsDbContext context, ILogger<SubjectService> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<List<SubjectDto>> GetAsync()
        {
            return await _context.Subjects.Select(x => new SubjectDto()
            {
                Id = x.Id,
                Name = x.Name,
            }).ToListAsync();
        }

        public async Task<SaveSubjectResponseDto> SaveAsync(SubjectDto request)
        {
            var response = new SaveSubjectResponseDto();
            try
            {
                var isNewSubject = request.Id == 0;
                var subject = isNewSubject ? new Subject() : await _context.Subjects.FirstOrDefaultAsync(r => r.Id == request.Id);

                if (subject == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Subject not found.";
                    response.StatusCode = StatusCodes.NotFound;
                    return response;
                }

                subject.Name = request.Name;

                if (isNewSubject)
                {
                    subject.CreationTime = DateTime.UtcNow;
                    _context.Subjects.Add(subject);
                }
                else
                {
                    subject.LastModificationTime = DateTime.UtcNow;
                    _context.Subjects.Update(subject);
                }

                if (await _context.SaveChangesAsync() > 0)
                {
                    response.IsSuccess = true;
                    response.Message = subject.Id.ToString();
                    response.StatusCode = StatusCodes.Success;
                }

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.StatusCode = StatusCodes.InternalServerError;
                response.Message = ex.Message;
                _logger.LogError($"Error while saving subject info: {ex}");
            }

            return response;
        }
    }
}
