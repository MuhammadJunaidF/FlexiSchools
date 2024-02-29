using FlexiSchools.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FlexiSchools.Application.Common.Interfaces
{
    public interface IFlexiSchoolsDbContext
    {
        DbSet<Student> Students { get; set; }
        DbSet<Subject> Subjects { get; set; }
        DbSet<LectureTheatre> LectureTheatres { get; set; }
        DbSet<Lecture> Lectures { get; set; }
        DbSet<Enrollment> Enrollments { get; set; }

        Task<int> SaveChangesAsync();
        int SaveChanges();
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
    }
}
