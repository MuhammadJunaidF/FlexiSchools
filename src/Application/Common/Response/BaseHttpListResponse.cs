using FlexiSchools.Application.Common.Models;

namespace FlexiSchools.Application.Common.Response
{
    public class BaseHttpListResponse<T>: ActionResponse
    {
        public List<T> Data { get; set; }
        public int TotalRecords { get; set; }
    }
}
