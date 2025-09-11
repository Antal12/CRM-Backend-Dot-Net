using CRM.Domain.Entities;
using System.Collections.Generic;

namespace CRM.Application.Services.Interfaces
{
    public interface IJwtService
    {
        string GenerateJwtToken(User user, IEnumerable<Role> roles);
    }
}
