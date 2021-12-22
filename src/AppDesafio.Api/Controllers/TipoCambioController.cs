using AppDesafio.Api.Models;
using AppDesafio.Application.Dtos;
using AppDesafio.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace AppDesafio.Api.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "Administrador")]
    public class TipoCambioController : ControllerBase
    {
        private readonly ITipoCambioService _tipoCambioService;
        public TipoCambioController(ITipoCambioService tipoCambioService)
        {
            _tipoCambioService = tipoCambioService;
        }

        [HttpGet("ObtenerPorCodigo")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ServiceResponseDto<ListarTipoCambioDto>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ServiceResponseDto<ListarTipoCambioDto>))]
        public async Task<IActionResult> ObtenerPorCodigo(string codigo)
        {
            try
            {
                return Ok(await _tipoCambioService.ObtenerPorCodigo(codigo));
            }
            catch (Exception)
            {
                var result = new ServiceResponseDto<string>();
                result.Messages.Add("Error: No se pudo obtener el tipo de cambio.");
                return BadRequest(result);
            }
        }

        [HttpGet("Listar")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ServiceResponseDto<ListarTipoCambioDto>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ServiceResponseDto<ListarTipoCambioDto>))]
        public async Task<IActionResult> Listar()
        {
            try
            {
                return Ok(await _tipoCambioService.Listar());
            }
            catch (Exception)
            {
                var result = new ServiceResponseDto<string>();
                result.Messages.Add("Error: No se pudo obtener la lista de tipos de cambio.");
                return BadRequest(result);
            }
        }

        [HttpPost("Agregar")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ServiceResponseDto<string>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ServiceResponseDto<string>))]
        public async Task<IActionResult> Agregar(AgregarTipoCambioDto dto)
        {
            try
            {
                return Ok(await _tipoCambioService.Agregar(dto));
            }
            catch (Exception ex)
            {
                var result = new ServiceResponseDto<string>();
                result.Messages.Add("Error: No se pudo registrar el tipo de cambio.");
                return BadRequest(result);
            }
        }

        [HttpPut("Actualizar")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ServiceResponseDto<string>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ServiceResponseDto<string>))]
        public async Task<IActionResult> Actualizar(string codigoIso, ActualizarTipoCambioDto dto)
        {
            try
            {
                return Ok(await _tipoCambioService.Actualizar(codigoIso, dto));
            }
            catch (Exception)
            {
                var result = new ServiceResponseDto<string>();
                result.Messages.Add("Error: No se pudo actualizar el tipo de cambio.");
                return BadRequest(result);
            }
        }

        [HttpGet("Aplicar")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ServiceResponseDto<AplicarTipoCambioDto>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ServiceResponseDto<AplicarTipoCambioDto>))]
        public async Task<IActionResult> Aplicar([FromQuery] AplicarTipoCambioInDto dto)
        {
            try
            {
                return Ok(await _tipoCambioService.Aplicar(dto));
            }
            catch (Exception)
            {
                var result = new ServiceResponseDto<AplicarTipoCambioDto>();
                result.Messages.Add("Error: No se pudo generar el tipo de cambio.");
                return BadRequest(result);
            }
        }
    }
}
