using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProjectKyzmat.BAL.DTOs.Payment;
using TestProjectKyzmat.BAL.DTOs.User;
using TestProjectKyzmat.BAL.Services.Interfaces;
using TestProjectKyzmat.Core.Entities;
using TestProjectKyzmat.Core.Entities.Common.Interfaces;
using TestProjectKyzmat.DAL;

namespace TestProjectKyzmat.BAL.Services
{
    public class PaymentService(IUserRepository userRepository, IPaymentRepository paymentRepository, ApplicationDbContext dbContext) : IPaymentService
    {
        const string NO_USER = "User not found";
        const string NO_FUNDS = "Insufficient funds";
        const string PAY_SUCCESS = "Payment successful";
        const string PAY_ERROR = "Payment processing error";
        const decimal AMOUNT_PAYMENT = 1.1m;

        public async Task<PaymentResponseDTO> MakePayment(string userName)
        {
            PaymentResponseDTO paymentResponseDTO = new();
            try
            {
                using var connection = dbContext.Database.GetDbConnection();
                await connection.OpenAsync();
                using var transaction = await connection.BeginTransactionAsync(IsolationLevel.RepeatableRead);
                await dbContext.Database.UseTransactionAsync(transaction);
                User? user = await userRepository.GetByUserNameAsync(userName);
                if (user == null)
                {
                    paymentResponseDTO.StatusCode = 500;
                    paymentResponseDTO.StatusMessage = NO_USER;
                }
                else
                {
                    if (user.Balance < AMOUNT_PAYMENT)
                    {
                        paymentResponseDTO.StatusCode = 400;
                        paymentResponseDTO.StatusMessage = NO_FUNDS;
                    }
                    else
                    {
                        user.Balance -= AMOUNT_PAYMENT;
                        await paymentRepository.AddAsync(new Payment
                        {
                            UserId = user.Id,
                            Amount = AMOUNT_PAYMENT
                        });
                        paymentResponseDTO.StatusCode = 200;
                        paymentResponseDTO.StatusMessage = PAY_SUCCESS;
                        paymentResponseDTO.AmountPayment = AMOUNT_PAYMENT;
                        paymentResponseDTO.BalanceUser = user.Balance;
                    }
                }              
                await paymentRepository.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch
            {
                paymentResponseDTO.StatusCode = 500;
                paymentResponseDTO.StatusMessage = PAY_ERROR;
            }
            return paymentResponseDTO;
        }
    }
}
