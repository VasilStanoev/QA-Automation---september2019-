using System;

namespace SeleniumBasicDemo
{
    class StartUp
    {
        public static void Main()
        {
            BankAccount acc = new BankAccount(1000);

            BankAccount secondacc = new BankAccount(3000);

            acc.Deposit(5000);

            secondacc.Deposit(30000);

            secondacc.Withdraw(200);

            System.Console.WriteLine(acc.Amount);

            System.Console.WriteLine(secondacc.Amount);
        }
    }
}
