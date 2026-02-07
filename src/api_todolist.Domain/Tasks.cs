using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using api_todolist.Core.Enums.Task;

namespace api_todolist.Domain
{
    public class Tasks : BaseEntity
    {
        public long UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public EPriority Priority { get; set; } 

        //propriedades de navegação

        public virtual User User { get; set; } = null!;

    }
}
