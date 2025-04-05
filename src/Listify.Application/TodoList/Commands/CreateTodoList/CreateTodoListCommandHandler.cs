using Listify.Domain.Entities;
using Listify.Domain.Interfaces;
using MediatR;

namespace Listify.Application.TodoList.Commands.CreateTodoList
{
    internal class CreateTodoListCommandHandler : IRequestHandler<CreateTodoListCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateTodoListCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<int> Handle(CreateTodoListCommand request, CancellationToken cancellationToken)
        {
            var entity = new TodoListEntity
            {
                Title = request.Title,
                Description = request.Description,
            };
            await _unitOfWork.BeginTransactionAsync();

            try
            {
                var id = await _unitOfWork.TodoLists.AddAsync(entity);
                await _unitOfWork.CommitTransactionAsync();
                return id;
            }
            catch
            {
                await _unitOfWork.RollbackTransactionAsync();
                throw;
            }           
        }
    }
}
