using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using api_todolist.Application.Interfaces;
using api_todolist.Application.Models.Users;
using api_todolist.Core.Enums.User;
using api_todolist.Core.Models;
using api_todolist.Core.Utils;
using api_todolist.Domain;
using api_todolist.Infra.Interfaces;

namespace api_todolist.Application.Services
{
    public class UserService : BaseService, IUserService
    {
        public UserService(IRepositoryFactory repositoryFactory) : base(repositoryFactory)
        {
        }
        public async Task<ResponseModel<dynamic>> ChangeStatus(ChangeUserStatusModel model)
        {
            var user = await _repository<User>().Get(u => u.Id == model.Id);
            if (user == null) return FactoryResponse<dynamic>.BadRequest("Usuário não encontrado");
            
            user.Status = model.Status;

            try
            {
                await _repository<User>().Update(user);
                return FactoryResponse<dynamic>.Success("Status do usuário atualizado com sucesso");
            }
            catch (Exception ex)

            {
                return FactoryResponse<dynamic>.BadRequest("Erro ao atualizar status do usuário", ex.Message);
            }
        }
        public async Task<ResponseModel<dynamic>> Create(CreateUserModel model)
        {
            var userExist = await _repository<User>().Get(u => u.Email == model.Email);
            if (userExist != null) return FactoryResponse<dynamic>.BadRequest("Email já cadastrado");

            var user = new User
            {
                Name = model.Name,
                Email = model.Email,
                Password = HashHelper.HashGeneration(model.Password),
                Status = EUserStatus.Active
            };

            try
            {
                await _repository<User>().Create(user);
                return FactoryResponse<dynamic>.SuccessfulCreation("Usuário criado com sucesso!");
            }
            catch (Exception ex)

            {
                return FactoryResponse<dynamic>.BadRequest("Erro ao criar usuário", ex.Message);
            }
        }
        public async Task<ResponseModel<dynamic>> GetAll()
        {
            var users = await _repository<User>().GetAll(null!);
            if(users == null) return FactoryResponse<dynamic>.NotFound("Nenhum usuário encontrado");

            var retorno = users.Select(u => new
            {
                u.Id,
                u.Name,
                u.Email,
                u.Status
            });
            return FactoryResponse<dynamic>.Success(users);
        }
        public async Task<ResponseModel<dynamic>> GetById(long id)
        {
            var user = await _repository<User>().Get(u => u.Id == id);
            if (user == null) return FactoryResponse<dynamic>.NotFound("Usuário não encontrado");

            var retorno = new
            {
                user.Id,
                user.Name,
                user.Email,
                user.Status
            };
            return FactoryResponse<dynamic>.Success(retorno);
        }
        public async Task<ResponseModel<dynamic>> Update(UpdateUserModel model)
        {
            var user = await _repository<User>().Get(u => u.Id == model.Id);
            if (user == null) return FactoryResponse<dynamic>.NotFound("Usuário não encontrado");
            var userEmailExist = await _repository<User>().Get(u => u.Email == model.Email && u.Id != model.Id);

            if (model.Name != null) user.Name = model.Name;
            if (model.Email != null && userEmailExist != null) user.Email = model.Email;

            try
            {
                await _repository<User>().Update(user);
                return FactoryResponse<dynamic>.Success("Usuário atualizado com sucesso");
            }
            catch (Exception ex)

            {
                return FactoryResponse<dynamic>.BadRequest("Erro ao atualizar o usuário", ex.Message);
            }
        }
    }
}
