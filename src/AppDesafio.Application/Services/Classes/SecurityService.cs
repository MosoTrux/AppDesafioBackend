using AppDesafio.Application.Dtos;
using AppDesafio.Domain.Services.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppDesafio.Application.Services
{
    public class SecurityService : ISecurityService
    {
        //private readonly IUnitOfWork _unitOfWork;
        //private readonly IMapper _mapper;
        //private readonly IPasswordService _passwordService;
        private readonly IAuthenticationService _authenticationService;
        public SecurityService(/*IUnitOfWork unitOfWork, IMapper mapper, IPasswordService passwordService, */IAuthenticationService authenticationService)
        {
            /*_unitOfWork = unitOfWork;
            _mapper = mapper;
            _passwordService = passwordService;*/
            _authenticationService = authenticationService;
        }
        //public async Task<ServiceResponseDto<AuthenticateDto>> Authentication(UserLoginDto dto)
        public ServiceResponseDto<AuthenticateDto> Authentication(UserLoginDto dto)
        {
            try
            {
                //if (!await ExistUser(userLoginDto.Usuario1)) throw new Exception("El usuario y/o la clave son incorrectos.");

                //var user = await _unitOfWork.UsuarioRepository.GetBy(d => d.Usuario1.Equals(userLoginDto.Usuario1)).FirstOrDefaultAsync().ConfigureAwait(false);
                //Valida la clave del usuario
                //if (!_passwordService.Check(user.Clave, userLoginDto.Clave)) throw new Exception("El usuario y/o la clave son incorrectos.");

                //Obtiene la lista de roles del usuario
                //List<string> roles = await _unitOfWork.UsuarioxRolRepository.GetAll()
                //    .Include(d => d.IdRolNavigation)
                //    .Where(d => d.IdUsuario == user.Id)
                //    .Select(d => d.IdRolNavigation.Descripcion)
                //    .ToListAsync().ConfigureAwait(false);

                var roles = new List<string>
                {
                    "Administrador",
                    "Operador"
                };

                //Genera el token
                return new ServiceResponseDto<AuthenticateDto>
                {
                    Data = new AuthenticateDto { Token = _authenticationService.GenerateToken(dto.Usuario, roles) },
                    IsSuccess = true
                };
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
