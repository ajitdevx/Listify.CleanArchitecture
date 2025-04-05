using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listify.Domain.Common
{
    public class BaseAuditableEntity : BaseEntity
    {
        public DateTimeOffset CreatedOn { get; set; }
        public string? CreatedBy { get; set; }
        public DateTimeOffset LastModifiedOn { get; set; }
        public string? LastModifiedBy { get; set; }
    }
}
