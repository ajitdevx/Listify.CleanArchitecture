using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listify.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        ITodoListRepository TodoLists { get; }
    }
}
