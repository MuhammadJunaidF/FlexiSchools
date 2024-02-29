using FlexiSchools.Application.Common.Enums;
using FlexiSchools.Application.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexiSchools.Application.Common
{
    public class EmmSession : IEmmSession
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public EmmSession(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public long? UserId => long.TryParse(_httpContextAccessor.HttpContext.Request.Headers[HeadersConst.UserId], out var UserId) ? UserId : null;

        public bool IsUserFilter => bool.TryParse(_httpContextAccessor.HttpContext.Request.Headers[HeadersConst.isUserFilter], out var IsUserFilter) ? IsUserFilter : false;
    }
}
