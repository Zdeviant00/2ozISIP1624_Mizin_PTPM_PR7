using System;
using System.Globalization;

namespace BankAccountNS
{
    /// <summary>
    /// Bank account demo class.
    /// </summary>
    public class BankAccount
    {
        private readonly string m_customerName;
        private decimal m_balance;

        private BankAccount() { }

        public BankAccount(string customerName, decimal balance)
        {
            m_customerName = customerName;
            m_balance = balance;
        }

        public string CustomerName
        {
            get { return m_customerName; }
        }

        public decimal Balance
        {
            get { return m_balance; }
        }

        public void Debit(decimal amount)
        {
            if (amount > m_balance)
            {
                throw new ArgumentOutOfRangeException("amount");
            }

            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("amount");
            }

            m_balance -= amount;
        }

        public void Credit(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("amount");
            }

            m_balance += amount;
        }

        public static void Main()
        {
            Console.Write("Enter initial balance: $");
            decimal initialBalance = decimal.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            BankAccount ba = new BankAccount("Mr. Pelevin V.", initialBalance);

            Console.Write("Enter Credit amount (0 to skip): $");
            decimal creditAmount = decimal.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            if (creditAmount != 0)
            {
                try
                {
                    ba.Credit(creditAmount);
                    Console.WriteLine($"✓ Credit successful. New balance: {ba.Balance:C}");
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine($"✗ Credit failed: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("→ Credit skipped");
            }
            Console.WriteLine();

            Console.Write("Enter Debit amount (0 to skip): $");
            decimal debitAmount = decimal.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            if (debitAmount != 0)
            {
                try
                {
                    ba.Debit(debitAmount);
                    Console.WriteLine($"✓ Debit successful. New balance: {ba.Balance:C}");
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine($"✗ Debit failed: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("→ Debit skipped");
            }
            Console.WriteLine();

            Console.WriteLine($"Current balance is: {ba.Balance:C} ===");
            Console.ReadLine();
        }
    }
}


