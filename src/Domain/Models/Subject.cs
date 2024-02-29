using FlexiSchools.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexiSchools.Domain.Models
{
    public class Subject : ModificationAuditEntity
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        public List<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
        public List<Lecture> Lectures { get; set; } = new List<Lecture>();
    }
}
