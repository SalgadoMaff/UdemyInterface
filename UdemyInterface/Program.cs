// See https://aka.ms/new-console-template for more information
using System.Globalization;
using UdemyInterface.Entities;
using UdemyInterface.Services;

int readNumber()
{
    Console.Write("Number: ");
    return int.Parse(Console.ReadLine());
}
DateTime readDate()
{
    Console.Write("Date (dd/MM/yyyy): ");
    return DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
}

double readTotalValue()
{
    Console.Write("Contract value: ");
    return double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);

}

int readInstallments()
{
    Console.Write("Enter number of installments: ");
    return int.Parse(Console.ReadLine());
}

try
{
    Console.WriteLine("Enter contract data: ");
    Contract contract = new Contract(readNumber(), readDate(), readTotalValue());
    int numberInstallments = readInstallments();
    ContractService contractService = new ContractService(new PaymentService());
    contractService.processContract(contract, numberInstallments);

}
catch (Exception e)
{

    Console.WriteLine(e.Message);
}
