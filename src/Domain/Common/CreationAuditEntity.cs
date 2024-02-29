namespace FlexiSchools.Domain.Common
{
    public abstract class CreationAuditEntity
    {
        public DateTime CreationTime { get; set; }

        public long? CreatedBy { get; set; }
    }
}
