using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listify.Application.TodoList.Commands.CreateTodoList
{

    public class CreateTodoListCommand : IRequest<int>
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public CreateTodoListCommand(string title, string description)
        {
            Title = title;
            Description = description;
        }
    }
}
