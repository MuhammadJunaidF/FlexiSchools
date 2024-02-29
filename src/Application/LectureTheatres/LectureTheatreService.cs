using FlexiSchools.Application.Common.Enums;
using FlexiSchools.Application.Common.Interfaces;
using FlexiSchools.Application.LectureTheatres.DTOs;
using FlexiSchools.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexiSchools.Application.LectureTheatres
{
    public class LectureTheatreService : ILectureTheatreService
    {
        private readonly IFlexiSchoolsDbContext _context;
        private readonly ILogger<LectureTheatreService> _logger;

        public LectureTheatreService(IFlexiSchoolsDbContext context, ILogger<LectureTheatreService> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<List<LectureTheatreDto>> GetAsync()
        {
            return await _context.LectureTheatres.Select(x => new LectureTheatreDto()
            {
                Name = x.Name,
                Capacity = x.Capacity,
            }).ToListAsync();
        }

        public async Task<SaveTheatreResponseDto> SaveAsync(LectureTheatreDto request)
        {
            var response = new SaveTheatreResponseDto();
            try
            {
                var isNewTheatre = request.Id == 0;
                var theatre = isNewTheatre ? new LectureTheatre() : await _context.LectureTheatres.FirstOrDefaultAsync(r => r.Id == request.Id);

                if (theatre == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Theatre not found.";
                    response.StatusCode = StatusCodes.NotFound;
                    return response;
                }

                theatre.Name = request.Name;
                theatre.Capacity = request.Capacity;

                if (isNewTheatre)
                {
                    theatre.CreationTime = DateTime.UtcNow;
                    _context.LectureTheatres.Add(theatre);
                }
                else
                {
                    theatre.LastModificationTime = DateTime.UtcNow;
                    _context.LectureTheatres.Update(theatre);
                }


                if (await _context.SaveChangesAsync() > 0)
                {
                    response.IsSuccess = true;
                    response.Message = theatre.Id.ToString();
                    response.StatusCode = StatusCodes.Success;
                }

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.StatusCode = StatusCodes.InternalServerError;
                response.Message = ex.Message;
                _logger.LogError($"Error while saving lecture theatre info: {ex}");
            }

            return response;
        }
    }
}
