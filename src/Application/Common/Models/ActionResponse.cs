using FlexiSchools.Application.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexiSchools.Application.Common.Models
{
    public class ActionResponse : BaseModel
    {
        public StatusCodes StatusCode { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
