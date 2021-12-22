using AppDesafio.Application.Dtos;
using System.Threading.Tasks;

namespace AppDesafio.Application.Services
{
    public interface ISecurityService
    {
        ServiceResponseDto<AuthenticateDto> Authentication(UserLoginDto dto);
        //Task<ServiceResponseDto<AuthenticateDto>> Authentication(UserLoginDto dto);
    }
}
