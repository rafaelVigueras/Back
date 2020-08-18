﻿using System;
using System.Collections.Generic;

namespace Back.Infrastructure.Data
{
    public partial class SystemUser
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool Status { get; set; }
        public int GenderId { get; set; }
        public DateTime CreationDate { get; set; }

        public virtual Gender Gender { get; set; }
    }
}
