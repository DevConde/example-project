using Example.Domain.Base;

namespace Example.Domain.Entities
{
    public class Todo : AuditableEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime? DueDate { get; set; }

        public void Complete()
        {
            IsCompleted = true;
        }
    }
}
