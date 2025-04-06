using AutoMapper;
using Listify.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listify.Application.TodoItem.Queries.GetTodoItems
{
    public class TodoItemBreifDto
    {
        public int Id { get; init; }
        public int ListId { get; init; }
        public string? Title { get; init; }
        public bool Done { get; init; }

        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<TodoItemEntity, TodoItemBreifDto>();
            }
        }
    }
}
