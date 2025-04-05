namespace Listify.Domain.Entities;

public class TodoListEntity : BaseAuditableEntity
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public IList<TodoItemEntity> Items { get; set; } = [];
}
