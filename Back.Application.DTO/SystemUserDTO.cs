using System;

namespace Back.Application.DTO
{
    public class SystemUserDTO
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool Status { get; set; }
        public int GenderId { get; set; }
        public DateTime CreationDate { get; set; }

        public GenderDTO Gender { get; set; }
    }
}
