using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProjectKyzmat.Core.Entities;

namespace TestProjectKyzmat.DAL
{
    public static class DataSeedConfiguration
    {
        public static void AddUsers(this DbSet<User> users)
        {
            users.AddRange(
                 new User
                 {
                     Id = 1,
                     UserName = "user",
                     PasswordHash = BCrypt.Net.BCrypt.HashPassword("qwerty12345"),
                     DateCreate = DateTime.UtcNow,
                     Balance = 8m
                 }
                );
        }
    }
}
