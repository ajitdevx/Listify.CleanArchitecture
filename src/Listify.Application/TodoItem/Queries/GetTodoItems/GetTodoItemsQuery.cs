using AutoMapper;
using Listify.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listify.Application.TodoItem.Queries.GetTodoItems
{
    public class GetTodoItemsQuery : IRequest<IReadOnlyCollection<TodoItemBreifDto>>
    {
        public int ListId { get; init; }
    }

    public class GetTodoItemsQueryHandler : IRequestHandler<GetTodoItemsQuery, IReadOnlyCollection<TodoItemBreifDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetTodoItemsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IReadOnlyCollection<TodoItemBreifDto>> Handle(GetTodoItemsQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<IReadOnlyCollection<TodoItemBreifDto>>(await _unitOfWork.TodoItems.GetAllAsync());
        }
    }
}
