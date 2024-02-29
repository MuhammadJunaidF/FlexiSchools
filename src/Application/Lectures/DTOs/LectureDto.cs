using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexiSchools.Application.Lectures.DTOs
{
    public class LectureDto
    {
        public long Id { get; set; }
        public string Subject { get; set; }
        public string LectureTheatre { get; set; }
        public byte DayOfWeek { get; set; }
        public TimeSpan StartTime { get; set; }
        public int DurationInMinutes { get; set; }
    }
}
