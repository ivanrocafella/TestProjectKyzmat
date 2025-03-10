using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectKyzmat.Core.Entities.Common.Interfaces
{
    public interface IDateFixEntity
    {
        public DateTime DateCreate { get; set; }
        public DateTime? DateUpdate { get; set; }
    }
}
