using FlexiSchools.Application.Common.Interfaces;
using FlexiSchools.Domain.Common;
using FlexiSchools.Domain.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace FlexiSchools.Infrastructure.Context
{
    public class FlexiSchoolsDbContext : DbContext, IFlexiSchoolsDbContext
    {
        public FlexiSchoolsDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<LectureTheatre> LectureTheatres { get; set; }
        public DbSet<Lecture> Lectures { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

        public async Task<int> SaveChangesAsync()
        {
            this.AddTime();
            return await base.SaveChangesAsync();
        }

        public override int SaveChanges()
        {
            this.AddTime();
            return base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }

        private void AddTime()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is BaseEntity && (
                    e.State == EntityState.Added
                    || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                if (entityEntry.State == EntityState.Added)
                {
                    ((BaseEntity)entityEntry.Entity).CreationTime = DateTime.UtcNow;
                }
                else if (entityEntry.State == EntityState.Modified)
                {
                    ((BaseEntity)entityEntry.Entity).LastModificationTime = DateTime.UtcNow;
                }
            }
        }

    }
}
