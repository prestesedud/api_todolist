using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using api_todolist.Domain;
using api_todolist.Infra.Interfaces;

namespace api_todolist.Application.Interfaces
{
    public interface IBaseService
    {
        IBaseRepository<T> _repository<T>() where T : BaseEntity;
        IBaseRelationRepository<T> _relationRepository<T>() where T : BaseEntityRelation;
    }

}
