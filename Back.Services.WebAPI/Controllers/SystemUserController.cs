using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Back.Application.DTO;
using Back.Application.Interface;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Back.Services.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemUserController : Controller
    {
        private readonly ISystemUserApplication systemUserApplication;
        public SystemUserController(ISystemUserApplication customersApplication)
        {
            systemUserApplication = customersApplication;
        }

        [HttpPost("Insert")]
        public IActionResult Insert([FromBody]SystemUserDTO userDTO)
        {
            if (userDTO == null)
                return BadRequest();
            var response = systemUserApplication.Insert(userDTO);
            if (response.IsSucces)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpPut("Update")]
        public IActionResult Update([FromBody]SystemUserDTO userDTO)
        {
            if (userDTO == null)
                return BadRequest();
            var response = systemUserApplication.Update(userDTO);
            if (response.IsSucces)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpDelete("Delete/{userId}")]
        public IActionResult Delete(string userId)
        {
            if (string.IsNullOrEmpty(userId))
                return BadRequest();
            var response = systemUserApplication.DeleteById(int.Parse(userId));
            if (response.IsSucces)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("Get/{userId}")]
        public IActionResult Get(string userId)
        {
            if (string.IsNullOrEmpty(userId))
                return BadRequest();
            var response = systemUserApplication.GetById(int.Parse(userId));
            if (response.IsSucces)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("GetByUser")]
        public IActionResult Get([FromBody]SystemUserDTO userDTO)
        {
            if (userDTO == null)
                return BadRequest();
            var response = systemUserApplication.GetByUser(userDTO);
            if (response.IsSucces)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var response = systemUserApplication.GetAll();
            if (response.IsSucces)
                return Ok(response);

            return BadRequest(response);
        }

    }
}