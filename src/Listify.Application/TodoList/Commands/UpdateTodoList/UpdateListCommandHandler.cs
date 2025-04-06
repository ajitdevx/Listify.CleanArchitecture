using Ardalis.GuardClauses;
using Listify.Application.TodoList.Commands.CreateTodoList;
using Listify.Domain.Entities;
using Listify.Domain.Interfaces;
using MediatR;

namespace Listify.Application.TodoList.Commands.UpdateTodoList
{
    internal class UpdateListCommandHandler : IRequestHandler<UpdateTodoListCommandWithId>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateListCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(UpdateTodoListCommandWithId request, CancellationToken cancellationToken)
        {
            var todoList = await _unitOfWork.TodoLists.GetByIdAsync(request.Id);
            
            Guard.Against.NotFound(request.Id, todoList);

            var entity = new TodoListEntity
            {
                Title = request.Title,
                Description = request.Description,
            };

            await _unitOfWork.TodoLists.UpdateAsync(entity, request.Id);
        }
    }
}
