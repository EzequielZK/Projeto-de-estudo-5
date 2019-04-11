using System.Globalization;
using StudyApp4.Entities.Exceptions;
using System.Text;

namespace StudyApp4.Entities
{
    class Account
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public double Balance { get; set; }
        public double WithdrawLimit { get; set; }

        public Account()
        {

        }

        public Account(int number, string name, double balance, double withdrawLimit)
        {
            Number = number;
            Name = name;
            Balance = balance;
            WithdrawLimit = withdrawLimit;
        }

        public void Deposit (double amount)
        {
            Balance += amount;
            
        }

        public void Withdraw(double amount)
        {
            if (amount > WithdrawLimit)
            {
                throw new DomainException("The amount must be lower than the withdraw limit.");
            }
            if (Balance <= amount)
            {
                throw new DomainException("Not enough cash!...Stranger"); //Re4 Reference...just a joke bro!
            }
            Balance -= amount;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Number: " + Number);
            sb.AppendLine("Holder: " + Name);
            sb.AppendLine("Withdraw limit " + WithdrawLimit.ToString("F2", CultureInfo.InvariantCulture));
            sb.AppendLine("New balance: " + Balance.ToString("F2",CultureInfo.InvariantCulture));

            return sb.ToString();
        }
    }
}
