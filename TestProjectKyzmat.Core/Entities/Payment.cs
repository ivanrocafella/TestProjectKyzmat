using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProjectKyzmat.Core.Entities.Common;

namespace TestProjectKyzmat.Core.Entities
{
    public class Payment : BaseEntity
    {
        public decimal Amount { get; set; }
        public DateTime DateCreate { get; set; }

        public int UserId { get; set; }
        public User? User { get; set; }
    }
}
