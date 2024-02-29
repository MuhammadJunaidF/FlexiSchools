using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexiSchools.Application.Common.Models.Response
{
    public class ApiResponse<T>
    {
        public bool Successful { get; set; }
        public string Message { get; set; }
        public T Result { get; set; }
    }
    public class ApiResponse
    {
        public bool Successful { get; set; }
        public string Message { get; set; }
    }
}
