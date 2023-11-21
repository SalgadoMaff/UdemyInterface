using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
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
                contract.Installments.Add(installment);
                
            }

        }
    }
}
