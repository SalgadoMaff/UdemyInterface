using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyInterface.Services
{
    internal class PaymentService : IOnlinePaymentService
    {
        public double interest(double amount, int months)
        {
            return amount + (amount * .01 * months);
        }

        public double paymentFee(double amount)
        {
            return amount * 1.02;
        }
    }
}
