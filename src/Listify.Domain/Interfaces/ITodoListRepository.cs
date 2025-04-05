using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listify.Domain.Interfaces
{
    public interface ITodoListRepository
    {
        Task<int> AddAsync(TodoListEntity entity);        
        Task DeleteAsync(int id);
        Task<IEnumerable<TodoListEntity>> GetAllAsync();
        Task<TodoListEntity?> GetByIdAsync(int id);
        Task UpdateAsync(TodoListEntity entity);
    }
}
