using System.ComponentModel.DataAnnotations;

namespace FlexiSchools.Domain.Common
{
    public class CoreEntity : BaseEntity
    {
        [Key]
        public long Id { get; set; }
        public string DeviceUniqueIdentifier { get; set; }
        public int TenantId { get; set; }
    }
}
