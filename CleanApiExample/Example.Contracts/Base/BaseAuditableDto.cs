namespace Example.Contracts.Base
{
    public record BaseAuditableDto : BaseDto
    {
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
