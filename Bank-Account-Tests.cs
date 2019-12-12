using NUnit.Framework;
using BankAccountProgram;
using System;

namespace Bank_Account_Tests
{
    [TestFixture] //Attribute that marks a class that contains tests
    public class BankAccountTests
    {
        [Test] //Test method
        public void MakeDepositTestOne()
        {
            var acc = new BankAccount(1000);

            acc.Deposit(1000);

            Assert.AreEqual(2000, acc.Amount);
        }
        [Test]

        public void MakeDepoditTestTwo()
        {
            var acc = new BankAccount(0);

            acc.Deposit(0);

            Assert.AreEqual(0, ;
        }
    }
}