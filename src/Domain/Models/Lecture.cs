using FlexiSchools.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexiSchools.Domain.Models
{
    public class Lecture : ModificationAuditEntity
    {
        [Key]
        public long Id { get; set; }
        public long SubjectId { get; set; }
        public long LectureTheatreId { get; set; }
        [Required]
        public byte DayOfWeek { get; set; }
        [Required]
        public TimeSpan StartTime { get; set; }
        [Required]
        public int DurationInMinutes { get; set; }
        [ForeignKey("SubjectId")]
        public Subject Subject { get; set; }
        [ForeignKey("LectureTheatreId")]
        public LectureTheatre LectureTheatre { get; set; }
    }
}
