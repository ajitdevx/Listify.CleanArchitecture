using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listify.Application.TodoList.Commands.CreateTodoList
{
    internal class CreateTodoListCommandHandler : IRequestHandler<CreateTodoListCommand, int>
    {
        public Task<int> Handle(CreateTodoListCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
