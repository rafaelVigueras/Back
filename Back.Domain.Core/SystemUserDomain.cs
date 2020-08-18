using Back.Domain.Interface;
using Back.Infrastructure.Data;
using Back.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Back.Domain.Core
{
    public class SystemUserDomain : ISystemUserDomain
    {
        public readonly ISystemUserRepository repository;

        public SystemUserDomain(ISystemUserRepository repository)
        {
            this.repository = repository;
        }
        public IEnumerable<SystemUser> GetAll()
        {
            return repository.GetAll();
        }
        public SystemUser GetByUser(SystemUser user)
        {
            return repository.GetByUser(user);
        }
        public SystemUser GetById(int id)
        {
            return repository.GetById(id);
        }
        public bool Insert(SystemUser user)
        {
            user.CreationDate = DateTime.Now;
            return repository.Insert(user);
        }
        public bool Update(SystemUser user)
        {
            return repository.Update(user);
        }
        public bool DeleteById(int id)
        {
            return repository.DeleteById(id);
        }
    }
}
