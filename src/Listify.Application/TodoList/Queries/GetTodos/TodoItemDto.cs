using Listify.Application.Common.Models;

namespace Listify.Application.TodoList.Queries.GetTodos
{
    public class TodoItemDto : BaseDto
    {
        public int ListId { get; set; }
        public string? Title { get; set; }
        public string? Note { get; set; }
        public int Priority { get; set; }
        public DateTime Remainder { get; set; }
        public bool Done { get; set; }
    }
}
