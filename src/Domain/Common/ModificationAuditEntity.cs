namespace FlexiSchools.Domain.Common
{
    public abstract class ModificationAuditEntity : CreationAuditEntity
    {
        public DateTime? LastModificationTime { get; set; }

        public long? ModifiedBy { get; set; }
    }
}
