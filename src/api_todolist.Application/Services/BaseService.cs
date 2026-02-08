    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using api_todolist.Application.Interfaces;
using api_todolist.Domain;
using api_todolist.Infra.Interfaces;

namespace api_todolist.Application.Services
{
    public class BaseService : IBaseService
    {
        private readonly IRepositoryFactory _repositoryFactory;
        public BaseService(IRepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
        }
        public IBaseRepository<T> _repository<T>() where T : BaseEntity
        {
            return _repositoryFactory.GetRepository<T>();
        }
        public IBaseRelationRepository<T> _relationRepository<T>() where T : BaseEntityRelation
        {
            return _repositoryFactory.GetRepositoryRelation<T>();
        }
    }
}
