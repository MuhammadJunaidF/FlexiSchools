using FlexiSchools.Application.Common.Filters;

namespace FlexiSchools.Application.Common.Request
{
    public class PagedAndSortedRequestDto
    {
        public string? SortDirection { get; set; }
        public int SkipCount { get; set; }
        [ValidateLength(2000, ErrorMessage = "MaxResultCount cannot be greater than 2000")]
        public int MaxResultCount { get; set; }
    }
}
