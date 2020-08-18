using Back.Infrastructure.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Transactions;

namespace Back.Domain.Interface
{
    public interface ISystemUserDomain
    {
        IEnumerable<SystemUser> GetAll();
        SystemUser GetByUser(SystemUser user);
        SystemUser GetById(int id);
        bool Insert(SystemUser user);
        bool Update(SystemUser user);
        bool DeleteById(int id);
    }
}
