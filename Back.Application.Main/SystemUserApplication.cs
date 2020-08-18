using AutoMapper;
using Back.Application.DTO;
using Back.Application.Interface;
using Back.Domain.Interface;
using Back.Infrastructure.Data;
using System;
using System.Collections.Generic;

namespace Back.Application.Main
{
    public class SystemUserApplication : ISystemUserApplication
    {
        private readonly ISystemUserDomain systemUserDomain;
        private readonly IMapper _mapper;

        public SystemUserApplication(ISystemUserDomain systemUserDomain, IMapper mapper)
        {
            this.systemUserDomain = systemUserDomain;
            _mapper = mapper;
        }
        public ResponseDTO<List<SystemUserDTO>> GetAll()
        {
            var response = new ResponseDTO<List<SystemUserDTO>>();
            try
            {               
                var responseDomain = systemUserDomain.GetAll();
                if (responseDomain != null)
                {
                    response.IsSucces = true;
                    response.Data = _mapper.Map<List<SystemUserDTO>>(responseDomain);
                    response.Message = "Ok!";
                }
            }
            catch (Exception ex)
            {
                response.IsSucces = false;
                response.Message = ex.Message;
            }
            return response;
        }
        public ResponseDTO<SystemUserDTO> GetByUser(SystemUserDTO user)
        {
            var response = new ResponseDTO<SystemUserDTO>();
            try
            {
                var systemUser = systemUserDomain.GetByUser(_mapper.Map<SystemUser>(user));
                response.Data = _mapper.Map<SystemUserDTO>(systemUser);
                if (response.Data != null)
                {
                    response.IsSucces = true;
                    response.Message = "Ok!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }
        public ResponseDTO<SystemUserDTO> GetById(int id)
        {
            var response = new ResponseDTO<SystemUserDTO>();
            try
            {
                var systemUser = systemUserDomain.GetById(id);
                response.Data = _mapper.Map<SystemUserDTO>(systemUser);
                if (response.Data != null)
                {
                    response.IsSucces = true;
                    response.Message = "Ok!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }
        public ResponseDTO<bool> Insert(SystemUserDTO user)
        {
            var response = new ResponseDTO<bool>();
            try
            {
                var systemUser = _mapper.Map<SystemUser>(user);
                response.Data = systemUserDomain.Insert(systemUser);
                if (response.Data)
                {
                    response.IsSucces = true;
                    response.Message = "Ok!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }
        public ResponseDTO<bool> Update(SystemUserDTO user)
        {
            var response = new ResponseDTO<bool>();
            try
            {
                var systemUser = _mapper.Map<SystemUser>(user);
                response.Data = systemUserDomain.Update(systemUser);
                if (response.Data)
                {
                    response.IsSucces = true;
                    response.Message = "Ok!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }
        public ResponseDTO<bool> DeleteById(int id)
        {
            var response = new ResponseDTO<bool>();
            try
            {
                response.Data = systemUserDomain.DeleteById(id);
                if (response.Data)
                {
                    response.IsSucces = true;
                    response.Message = "Ok!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }
    }
}
