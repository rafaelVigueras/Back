using System;
using System.Collections.Generic;
using System.Text;

namespace Back.Application.DTO
{
    public class GenderDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public virtual List<SystemUserDTO> SystemUser { get; set; }
    }
}
