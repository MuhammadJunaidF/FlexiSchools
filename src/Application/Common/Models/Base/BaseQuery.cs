using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FlexiSchools.Application.Common.Models.Base
{
    public abstract class BaseQuery
    {
        public Guid? Identifier { get; set; }
        [JsonIgnore]
        public string? CallbackUrl { get; set; }
        [JsonIgnore]
        public string? ClientId { get; set; }
    }
}
