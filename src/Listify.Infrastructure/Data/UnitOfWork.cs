using Listify.Domain.Entities;
using Listify.Domain.Interfaces;
using Listify.Infrastructure.Repositories;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.Common;

namespace Listify.Infrastructure.Data
{
    internal class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(ITodoListRepository todoListRepository, ITodoItemRepository todoItemRepository)
        {
            TodoLists = todoListRepository;
            TodoItems = todoItemRepository;
        }
        public ITodoListRepository TodoLists { get; }
        public ITodoItemRepository TodoItems { get; }
    }
}
