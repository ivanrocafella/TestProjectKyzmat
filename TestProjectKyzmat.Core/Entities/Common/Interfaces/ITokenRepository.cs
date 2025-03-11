using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectKyzmat.Core.Entities.Common.Interfaces
{
    public interface ITokenRepository : IRepository<Token>
    {
        Task<Token?> GetByValueAsync(string name);
    }
}
