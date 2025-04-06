using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listify.Application.TodoItem.Commands.DeleteTodoItem
{
    public class DeleteTodoItemCommand : IRequest
    {
        public int Id { get; private set; }
        public DeleteTodoItemCommand(int id) => Id = id;
    }
}
