using AutoMapper;
using Listify.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listify.Application.TodoList.Queries.GetTodos
{
    public class GetTodoByIdQuery : IRequest<TodoListDto>
    {
        public int Id { get; set; }
        public GetTodoByIdQuery(int id)
        {
            Id = id;
        }
    }

    public class GetTodoByIdQueryHandler : IRequestHandler<GetTodoByIdQuery, TodoListDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetTodoByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<TodoListDto> Handle(GetTodoByIdQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<TodoListDto>(await _unitOfWork.TodoLists.GetByIdAsync(request.Id));
        }
    }
}
