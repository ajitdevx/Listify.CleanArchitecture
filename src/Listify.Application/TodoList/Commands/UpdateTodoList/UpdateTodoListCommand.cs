using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listify.Application.TodoList.Commands.UpdateTodoList
{
    public class UpdateTodoListCommand : IRequest
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public UpdateTodoListCommand(string title, string description)
        {
            Title = title;
            Description = description;
        }
    }

    public class UpdateTodoListCommandWithId : UpdateTodoListCommand
    {
        public int Id { get; set; }
        public UpdateTodoListCommandWithId(string title, string description, int id) : base(title, description)
        {
            Id = id;
        }
    }
}
