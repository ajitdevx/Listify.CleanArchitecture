using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listify.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TodoListEntity> TodoLists { get; }
        IRepository<TodoItemEntity> TodoItems { get; }
        Task<int> CompleteAsync();
    }
}
