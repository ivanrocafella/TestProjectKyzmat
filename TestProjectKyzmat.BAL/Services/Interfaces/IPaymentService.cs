using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProjectKyzmat.BAL.DTOs.Payment;

namespace TestProjectKyzmat.BAL.Services.Interfaces
{
    public interface IPaymentService
    {
        Task<PaymentResponseDTO> MakePayment(string userName);
    }
}
