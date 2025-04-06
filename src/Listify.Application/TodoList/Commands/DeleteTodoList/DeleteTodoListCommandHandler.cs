using Ardalis.GuardClauses;
using Listify.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listify.Application.TodoList.Commands.DeleteTodoList
{
    public class DeleteTodoListCommandHandler : IRequestHandler<DeleteTodoListCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteTodoListCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(DeleteTodoListCommand request, CancellationToken cancellationToken)
        {
            var todoList = await _unitOfWork.TodoLists.GetByIdAsync(request.Id);
            Guard.Against.NotFound(request.Id, todoList);

            await _unitOfWork.TodoLists.DeleteAsync(request.Id);
        }
    }
}
