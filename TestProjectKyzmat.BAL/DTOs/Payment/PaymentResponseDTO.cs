using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProjectKyzmat.Core.Entities;

namespace TestProjectKyzmat.BAL.DTOs.Payment
{
    public class PaymentResponseDTO
    {
        public int StatusCode { get; set; }
        public string? StatusMessage { get; set; }
        public decimal BalanceUser { get; set; }
        public decimal AmountPayment { get; set; }
    }
}
