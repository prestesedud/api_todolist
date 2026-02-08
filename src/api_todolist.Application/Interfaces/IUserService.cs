using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using api_todolist.Application.Models.Users;
using api_todolist.Core.Models;

namespace api_todolist.Application.Interfaces
{
    public interface IUserService
    {
            Task<ResponseModel<dynamic>> Create(CreateUserModel model);
            Task<ResponseModel<dynamic>> Update(UpdateUserModel model);
            Task<ResponseModel<dynamic>> GetById(long id);
            Task<ResponseModel<dynamic>> GetAll();
            Task<ResponseModel<dynamic>> ChangeStatus(ChangeUserStatusModel model); 
    }
}
