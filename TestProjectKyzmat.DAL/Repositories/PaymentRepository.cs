﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProjectKyzmat.Core.Entities.Common.Interfaces;
using TestProjectKyzmat.Core.Entities;

namespace TestProjectKyzmat.DAL.Repositories
{
    public class PaymentRepository(ApplicationDbContext context) : Repository<Payment>(context), IPaymentRepository
    {
    }
}
