using Example.Contracts.Base;

namespace Example.Contracts.DTOs
{
    public record TodoDto : BaseAuditableDto
    {
        public int Id { get; set; }
        /// <example>
        /// My daily todo
        /// </example>
        public required string Title { get; set; }
        /// <example>
        /// I must fill that form
        /// </example>
        public string Description { get; set; }
        /// <example>
        /// false
        /// </example>
        public bool IsCompleted { get; set; }
        public DateTime? DueDate { get; set; }
    }
}
