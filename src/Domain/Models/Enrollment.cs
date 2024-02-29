using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexiSchools.Domain.Models
{
    public class Enrollment
    {
        [Key]
        public long Id { get; set; }
        public long StudentId { get; set; }
        public long SubjectId { get; set; }
        [ForeignKey("StudentId")]
        public Student Student { get; set; }
        [ForeignKey("SubjectId")]
        public Subject Subject { get; set; }
    }
}
