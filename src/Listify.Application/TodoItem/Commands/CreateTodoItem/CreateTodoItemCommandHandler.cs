using Listify.Domain.Entities;
using Listify.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listify.Application.TodoItem.Commands.CreateTodoItem
{
    public class CreateTodoItemCommandHandler : IRequestHandler<CreateTodoItemCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateTodoItemCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<int> Handle(CreateTodoItemCommand request, CancellationToken cancellationToken)
        {
            var entity = new TodoItemEntity()
            {
                Title = request.Title,
                ListId = request.ListId,
            };
            return await _unitOfWork.TodoItems.AddAsync(entity);
        }
    }
}
