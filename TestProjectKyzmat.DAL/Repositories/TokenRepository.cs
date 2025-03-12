using Microsoft.EntityFrameworkCore;
using TestProjectKyzmat.Core.Entities;
using TestProjectKyzmat.Core.Entities.Common.Interfaces;

namespace TestProjectKyzmat.DAL.Repositories
{
    public class TokenRepository(ApplicationDbContext context) : Repository<Token>(context), ITokenRepository
    {
        public async Task<Token?> GetByValueAsyncForRead(string value) => await context.Set<Token>().AsNoTracking().FirstOrDefaultAsync(e => e.Value == value);
    }
}
