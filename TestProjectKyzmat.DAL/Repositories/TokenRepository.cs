using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProjectKyzmat.Core.Entities.Common.Interfaces;
using TestProjectKyzmat.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace TestProjectKyzmat.DAL.Repositories
{
    public class TokenRepository(ApplicationDbContext context) : Repository<Token>(context), ITokenRepository
    {
        public async Task<Token?> GetByValueAsync(string value) => await context.Set<Token>().FirstOrDefaultAsync(e => e.Value == value);
    }
}
