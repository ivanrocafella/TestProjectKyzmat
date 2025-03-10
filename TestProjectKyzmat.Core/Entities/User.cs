using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProjectKyzmat.Core.Entities.Common;

namespace TestProjectKyzmat.Core.Entities
{
    public class User : BaseEntity
    {
        public string? UserName { get; set; }
        public string? PasswordHash { get; set; }
        public decimal Balance { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime DateUpdate { get; set; }
        public DateTime DateAttempt { get; set; }

        public ICollection<Token> Tokens { get;} = [];
        public ICollection<Payment> Payments { get;} = [];
    }
}
