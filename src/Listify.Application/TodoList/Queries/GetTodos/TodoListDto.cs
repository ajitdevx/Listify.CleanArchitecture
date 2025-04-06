using AutoMapper;
using Listify.Application.Common.Models;
using Listify.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listify.Application.TodoList.Queries.GetTodos
{
    public class TodoListDto : BaseDto
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public IList<TodoItemDto> Items { get; init; }
        public TodoListDto()
        {
            Items = [];
        }

        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<TodoListEntity, TodoListDto>();
            }
        }
    }
}
