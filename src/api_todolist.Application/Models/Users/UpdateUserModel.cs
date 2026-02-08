using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api_todolist.Application.Models.Users
{
    public class UpdateUserModel
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }

    }
}
