using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Test
{
    [TestFixture]
    public class BankTest
    {
        [Test]
        public void CanDepositMoney()
        {
            BankAccount bankAccount = new BankAccount();

            bankAccount.Deposit(1000);

            Assert.AreEqual(1000, bankAccount.Balance);

        }
        [Test]
        public void CanWithdrapMoney()
        {
            BankAccount bankAccount = new BankAccount();

            bankAccount.Withdraw(1000);

            Assert.AreEqual(-1000, bankAccount.Balance);
        }
    }
 
}
