using System;
using System.Globalization;
using StudyApp4.Entities;
using StudyApp4.Entities.Exceptions;
namespace StudyApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter account data");
                Console.Write("Number: ");
                int number = int.Parse(Console.ReadLine());
                Console.Write("Holder: ");
                string name = Console.ReadLine();
                Console.Write("Initial balance: ");
                double balance = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);
                Console.Write("Withdraw Limit: ");
                double limit = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);
                Console.WriteLine();

                Account account = new Account(number, name, balance, limit);

                Console.Write("Enter amount for withdraw: ");
                double amount = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);

                account.Withdraw(amount);

                Console.WriteLine(account);
                Console.ReadLine();
            }
            catch (DomainException e)
            {
                Console.WriteLine("Error on withdraw: " + e.Message);
            }
            catch (FormatException e)
            {
                Console.WriteLine("Format error: " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Unexpected error: " + e.Message);
            }

            Console.ReadLine();
        }
    }
}
