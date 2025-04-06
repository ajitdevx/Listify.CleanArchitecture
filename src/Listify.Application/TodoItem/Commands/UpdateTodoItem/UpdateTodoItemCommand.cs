using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listify.Application.TodoItem.Commands.UpdateTodoItem
{
    public class UpdateTodoItemCommand : IRequest
    {
        public int ListId { get; private set; }
        public string? Title { get; private set; }
        public UpdateTodoItemCommand(int listId, string? title)
        {
            ListId = listId;
            Title = title;
        }
    }

    public class UpdateTodoItemCommandWithId : UpdateTodoItemCommand
    {
        public UpdateTodoItemCommandWithId(int listId, string? title, int id) : base(listId, title)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
