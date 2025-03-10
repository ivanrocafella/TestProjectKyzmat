using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProjectKyzmat.Core.Entities.Common;
using TestProjectKyzmat.Core.Entities.Common.Interfaces;

namespace TestProjectKyzmat.Core.Entities
{
    public class User : BaseEntity, IDateFixEntity
    {
        public required string UserName { get; set; }
        public required string PasswordHash { get; set; }
        public decimal Balance { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime? DateUpdate { get; set; }

        public virtual ICollection<Token> Tokens { get; set; } = [];
        public virtual ICollection<Payment> Payments { get; set; } = [];
    }
}
