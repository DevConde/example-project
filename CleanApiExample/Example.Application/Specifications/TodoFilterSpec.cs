using Example.Domain.Entities;

namespace Example.Application.Specifications
{
    public sealed class TodoFilterSpec : Specification<Todo>
    {
        public TodoFilterSpec(int? id = null, bool? isComplete = null)
        {
            Criteria = t =>
                (!id.HasValue || t.Id == id.Value) &&
                (!isComplete.HasValue || t.IsCompleted == isComplete.Value);
        }
    }
}
