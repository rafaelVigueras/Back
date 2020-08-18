using System;
using System.Collections.Generic;
using System.Text;

namespace Back.Application.DTO
{
        public class ResponseDTO<T>
        {
            public bool IsSucces { get; set; }
            public T Data { get; set; }
            public string Message { get; set; }
        }
}
