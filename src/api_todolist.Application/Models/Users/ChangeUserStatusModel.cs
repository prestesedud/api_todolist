using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using api_todolist.Core.Enums.User;

namespace api_todolist.Application.Models.Users
{
    public class ChangeUserStatusModel
    {
        public long Id { get; set; }
        public EUserStatus Status { get; set; }
    }

}
