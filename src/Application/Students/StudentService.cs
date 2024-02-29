using FlexiSchools.Application.Common.Enums;
using FlexiSchools.Application.Common.Interfaces;
using FlexiSchools.Application.Students.Dtos;
using FlexiSchools.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexiSchools.Application.Students
{
    public class StudentService : IStudentService
    {
        private readonly IFlexiSchoolsDbContext _context;
        private readonly ILogger<StudentService> _logger;

        public StudentService(IFlexiSchoolsDbContext context, ILogger<StudentService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<List<StudentDto>> GetAsync()
        {
            return await _context.Students.Select(s => new StudentDto()
            {
                Id = s.Id,
                FirstName = s.FirstName,
                LastName = s.LastName,
                Address = s.Address,
                DateOfBirth = s.DateOfBirth,
            }).ToListAsync();
           
        }

        public async Task<SaveStudentResponseDto> SaveAsync(StudentDto request)
        {
            var response = new SaveStudentResponseDto();
            try
            {
                var isNewStudent = request.Id == 0;
                var student = isNewStudent ? new Student() : await _context.Students.FirstOrDefaultAsync(r => r.Id == request.Id);

                if (student == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Student not found.";
                    response.StatusCode = StatusCodes.NotFound;
                    return response;
                }

                student.FirstName = request.FirstName;
                student.LastName = request.LastName;
                student.DateOfBirth = request.DateOfBirth;
                student.Address= request.Address;

                if (isNewStudent)
                {
                    student.CreationTime = DateTime.UtcNow;
                    _context.Students.Add(student);
                }
                else
                {
                    student.LastModificationTime = DateTime.UtcNow;
                    _context.Students.Update(student);
                }

                if (await _context.SaveChangesAsync() > 0)
                {
                    response.IsSuccess = true;
                    response.Message = student.Id.ToString();
                    response.StatusCode = StatusCodes.Success;
                }

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.StatusCode = StatusCodes.InternalServerError;
                response.Message = ex.Message;
                _logger.LogError($"Error while saving student info: {ex}");
            }

            return response;
        }

        public async Task<EnrollmentResponseDto> EnrollAsync(EnrollmentRequestDto request)
        {
            var response = new EnrollmentResponseDto();
            try
            {
                var enrollment = new Enrollment();

                var student = _context.Students.Find(request.StudentId);
                var subject = _context.Subjects.Find(request.SubjectId);

                if (student == null || subject == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Record not found.";
                    response.StatusCode = StatusCodes.NotFound;
                    return response;
                }

                // Check if the student has more than 10 hours of lectures in a week
                var totalHours = _context.Enrollments
                    .Include(e => e.Subject)
                    .ThenInclude(s => s.Lectures)
                    .Where(e => e.StudentId == request.StudentId)
                    .Sum(e => e.Subject.Lectures.Sum(l => l.DurationInMinutes));

                if (totalHours + subject.Lectures.Sum(l => l.DurationInMinutes) > 600) // 10 hours * 60 minutes
                {
                    response.IsSuccess = false;
                    response.Message = "Student cannot have more than 10 hours of lectures in a week";
                    response.StatusCode = StatusCodes.NotFound;
                    return response;
                }

                enrollment.SubjectId = request.SubjectId;
                enrollment.StudentId = request.StudentId;

                _context.Enrollments.Add(enrollment);

                if (await _context.SaveChangesAsync() > 0)
                {
                    response.IsSuccess = true;
                    response.Message = enrollment.Id.ToString();
                    response.StatusCode = StatusCodes.Success;
                }
            }
            catch(Exception ex)
            {
                response.IsSuccess = false;
                response.StatusCode = StatusCodes.InternalServerError;
                response.Message = ex.Message;
                _logger.LogError($"Error while enrolling student info: {ex}");
            }

            return response;
        }

    }
}
