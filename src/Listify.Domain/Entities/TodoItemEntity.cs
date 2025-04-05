using Listify.Domain.Common;
using Listify.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listify.Domain.Entities;

public class TodoItemEntity : BaseAuditableEntity
{
    public int ListId { get; set; }
    public string? Title { get; set; }
    public string? Note { get; set; }
    public PriorityLevel Priority { get; set; }
    public DateTime Remainder { get; set; }
    public bool Done { get; set; }
    public TodoListEntity List { get; set; } = null!;
}
