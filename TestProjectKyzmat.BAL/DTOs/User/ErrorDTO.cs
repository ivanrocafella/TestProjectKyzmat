using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectKyzmat.BAL.DTOs.User
{
    public class ErrorDTO(string? message)
    {
        public string? Message { get; set; } = message;
    }
}
