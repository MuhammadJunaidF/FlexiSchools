using System.ComponentModel.DataAnnotations.Schema;

namespace FlexiSchools.Domain.Common
{
    public class BaseEntity
    {
        public DateTime CreationTime { get; set; }
        public DateTime? LastModificationTime { get; set; }
    }
}
