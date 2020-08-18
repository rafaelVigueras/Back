using Back.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Back.Infrastructure.Interface
{
    public interface ISystemUserRepository
    {
        IEnumerable<SystemUser> GetAll();
        SystemUser GetByUser(SystemUser user);
        SystemUser GetById(int id);
        bool Insert(SystemUser user);
        bool Update(SystemUser user);
        bool DeleteById(int id);
    }
}
