using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexiSchools.Application.Students.Dtos
{
    public class EnrollmentRequestDto
    {
        public long StudentId { get; set; }
        public long SubjectId { get; set; }
    }
}
