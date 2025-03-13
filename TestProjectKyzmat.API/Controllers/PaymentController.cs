using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using TestProjectKyzmat.BAL.DTOs.Payment;
using TestProjectKyzmat.BAL.DTOs.User;
using TestProjectKyzmat.BAL.Services.Interfaces;
using TestProjectKyzmat.Core.Entities;
using TestProjectKyzmat.Core.Entities.Common.Interfaces;
using TestProjectKyzmat.DAL;

namespace TestProjectKyzmat.API.Controllers
{
    public class PaymentController(IPaymentService paymentService) : ApiController
    {
        private const string INVAL_TOKEN = "Invalid token";

        [HttpPost("payment")]
        [Authorize]
        public async Task<IActionResult> Payment()
        {
            string? userName = User.Identity?.Name;            
            if (!string.IsNullOrEmpty(userName))
            {
                PaymentResponseDTO responseDTO = await paymentService.MakePayment(userName);
                if (responseDTO.StatusCode == StatusCodes.Status200OK)
                    return StatusCode(responseDTO.StatusCode, new { status_message = responseDTO.StatusMessage, new_balance = responseDTO.BalanceUser, amount_payment = responseDTO.AmountPayment});
                return StatusCode(responseDTO.StatusCode, new { status_message = responseDTO.StatusMessage});
            }
            return Unauthorized(INVAL_TOKEN);
        }
    }
}
