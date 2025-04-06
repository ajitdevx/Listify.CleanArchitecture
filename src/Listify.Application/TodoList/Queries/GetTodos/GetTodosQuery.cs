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
    public class GetTodosQuery : IRequest<IEnumerable<TodoListDto>>
    {
    }

    public class GetTodosQueryHandler : IRequestHandler<GetTodosQuery, IEnumerable<TodoListDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetTodosQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<TodoListDto>> Handle(GetTodosQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<IEnumerable<TodoListDto>>(await _unitOfWork.TodoLists.GetAllAsync());
        }
    }
}
