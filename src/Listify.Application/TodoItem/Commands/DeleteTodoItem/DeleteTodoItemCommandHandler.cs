using Ardalis.GuardClauses;
using Listify.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listify.Application.TodoItem.Commands.DeleteTodoItem
{
    internal class DeleteTodoItemCommandHandler : IRequestHandler<DeleteTodoItemCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteTodoItemCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(DeleteTodoItemCommand request, CancellationToken cancellationToken)
        {
            var todoItem = await _unitOfWork.TodoItems.GetByIdAsync(request.Id);
            Guard.Against.NotFound(request.Id, todoItem);
            await _unitOfWork.TodoItems.DeleteAsync(request.Id);
        }
    }
}
