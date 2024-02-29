using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexiSchools.Domain.Interfaces
{
    public interface IDeletionUser
    {
        public DateTime? DeletedOnUtc { get; set; }
        public long? DeletedUserId { get; set; }
    }
}
