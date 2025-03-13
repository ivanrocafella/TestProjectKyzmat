using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProjectKyzmat.BAL.DTOs.User;
using TestProjectKyzmat.Core.Entities;

namespace TestProjectKyzmat.BAL.Services.Interfaces
{
    public interface IUserService
    {
        Task<Token?> AuthUserAsync(LoginRequestDTO userRequestDTO);
        Task<bool> LogoutUserAsync(string tokenValue);
    }
}
