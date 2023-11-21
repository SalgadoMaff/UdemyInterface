using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyInterface.Entities;

namespace UdemyInterface.Services
{
    internal class ContractService
    {
        public IOnlinePaymentService _onlinePaymentService;

        public ContractService(IOnlinePaymentService onlinePaymentService)
        {
            _onlinePaymentService = onlinePaymentService;
        }

        public void processContract(Contract contract,int months)
        {
            for (int i = 1; i <=months; i++)
            {
                Installment installment = new Installment(contract.Date.AddMonths(i),contract.TotalValue/months);
                installment.Amount = _onlinePaymentService.paymentFee(_onlinePaymentService.interest(installment.Amount, i));
                Console.Write(installment.DueDate.ToString("dd/MM/yyyy") + " - R$" + installment.Amount.ToString("F2", CultureInfo.InvariantCulture));
                Console.WriteLine();

            }

        }
    }
}
