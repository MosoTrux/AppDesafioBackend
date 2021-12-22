using System.Collections.Generic;

namespace AppDesafio.Domain.Services.Security
{
    public interface IAuthenticationService
    {
        string GenerateToken(string user, List<string> roles);
    }
}
