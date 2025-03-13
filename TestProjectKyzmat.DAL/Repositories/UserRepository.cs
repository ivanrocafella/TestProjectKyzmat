using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProjectKyzmat.Core.Entities;
using TestProjectKyzmat.Core.Entities.Common.Interfaces;

namespace TestProjectKyzmat.DAL.Repositories
{
    public class UserRepository(ApplicationDbContext context) : Repository<User>(context), IUserRepository
    {
        public async Task<User?> GetByUserNameAsync(string userName) => await context.Set<User>().FirstOrDefaultAsync(e => e.UserName == userName);

        public async Task<User?> GetByUserNameAsyncForRead(string userName) => await context.Set<User>().AsNoTracking().FirstOrDefaultAsync(e => e.UserName == userName);
    }
}
