using Back.Application.DTO;
using System;
using System.Collections.Generic;

namespace Back.Application.Interface
{
    public interface ISystemUserApplication
    {
        ResponseDTO<List<SystemUserDTO>> GetAll();
        ResponseDTO<SystemUserDTO> GetByUser(SystemUserDTO user);
        ResponseDTO<SystemUserDTO> GetById(int id);
        ResponseDTO<bool> Insert(SystemUserDTO user);
        ResponseDTO<bool> Update(SystemUserDTO user);
        ResponseDTO<bool> DeleteById(int id);
    }
}
