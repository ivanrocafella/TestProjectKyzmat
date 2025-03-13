using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectKyzmat.Core.Entities.Common.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User?> GetByUserNameAsyncForRead(string userName);
        Task<User?> GetByUserNameAsync(string userName);
    }
}
