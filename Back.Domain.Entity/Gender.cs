using System;
using System.Collections.Generic;

namespace Back.Infrastructure.Data
{
    public partial class Gender
    {
        public Gender()
        {
            SystemUser = new HashSet<SystemUser>();
        }

        public int Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<SystemUser> SystemUser { get; set; }
    }
}
