using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProjectKyzmat.BAL.DTOs.User;
using TestProjectKyzmat.BAL.Services.Interfaces;
using TestProjectKyzmat.BAL.Services.JwtFeatures;
using TestProjectKyzmat.Core.Entities;
using TestProjectKyzmat.Core.Entities.Common.Interfaces;

namespace TestProjectKyzmat.BAL.Services
{
    public class UserService(IUserRepository userRepository, ITokenRepository tokenRepository, JwtHandler jwtHandler) : IUserService
    {
        public async Task<Token?> AuthUserAsync(LoginRequestDTO userRequestDTO)
        { 
            User? user = await userRepository.GetByUserNameAsyncForRead(userRequestDTO.UserName);
            if (user != null)
            {
                if (BCrypt.Net.BCrypt.Verify(userRequestDTO.Password, user.PasswordHash))
                {
                    var tokenValue = jwtHandler.GenerateToken(user);
                    Token token = new()
                    { 
                        Value = tokenValue,
                        ExpiresAt = JwtHandler.ReadToken(tokenValue).ValidTo,
                        UserId = user.Id    
                    };
                    await tokenRepository.AddAsync(token);
                    await tokenRepository.SaveChangesAsync();
                    return token;
                }
            }
            return null;
        }

        public async Task<bool> LogoutUserAsync(string tokenValue)
        {
            Token? tokenEnt = await tokenRepository.GetByValueAsyncForRead(tokenValue);
            if (tokenEnt != null)
            {
                await tokenRepository.RemoveByIdAsync(tokenEnt.Id);
                await tokenRepository.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
