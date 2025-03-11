using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using TestProjectKyzmat.Core.Entities.Common;
using TestProjectKyzmat.Core.Entities.Common.Interfaces;

namespace TestProjectKyzmat.Core.Entities
{
    public class Token : BaseEntity, IDateFixEntity
    {
        public required string Value { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime? DateUpdate { get; set; }
        public DateTime ExpiresAt { get; set; }

        public int UserId { get; set; }
        public User? User { get; set; }
    }
}
