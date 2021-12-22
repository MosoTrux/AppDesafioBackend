using AppDesafio.Application.Dtos;
using AppDesafio.Application.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;

namespace AppDesafio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly ISecurityService _securityService;
        public AuthenticateController(ISecurityService securityService)
        {
            _securityService = securityService;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ServiceResponseDto<AuthenticateDto>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ServiceResponseDto<AuthenticateDto>))]
        public IActionResult Authentication(UserLoginDto dto)
        {
            try
            {
                return Ok(_securityService.Authentication(dto));
            }
            catch (Exception)
            {
                var result = new ServiceResponseDto<AuthenticateDto>();
                result.Messages.Add("Error: No se pudo generar el token.");
                return BadRequest(result);
            }
        }
    }
}