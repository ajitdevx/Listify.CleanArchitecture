using Ardalis.GuardClauses;
using Listify.Domain.Entities;
using Listify.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listify.Application.TodoItem.Commands.UpdateTodoItem
{
    public class UpdateTodoItemCommandHandler : IRequestHandler<UpdateTodoItemCommandWithId>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateTodoItemCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(UpdateTodoItemCommandWithId request, CancellationToken cancellationToken)
        {
            var todoItem = await _unitOfWork.TodoItems.GetByIdAsync(request.Id);
            Guard.Against.NotFound(request.Id, todoItem);

            var entity = new TodoItemEntity()
            {
                Title = request.Title,
            };
            await _unitOfWork.TodoItems.UpdateAsync(entity, request.Id);
        }
    }
}
