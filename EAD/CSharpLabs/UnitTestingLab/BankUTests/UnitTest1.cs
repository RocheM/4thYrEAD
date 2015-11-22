using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestingLab;


namespace BankUTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestDeposit()
        {
            BankAccount testAccount = new BankAccount("Hello", "Test", 100);
            testAccount.Deposit(100);
            testAccount.Deposit(100);
            Assert.AreEqual(testAccount.Balance, 200);
        }


        [TestMethod]
        public void TestWithdraw()
        {
            BankAccount testAccount = new BankAccount("Hello", "Test", 100);
            testAccount.Deposit(1000);
            testAccount.Withdraw(100);
            testAccount.Withdraw(100);
            Assert.AreEqual(testAccount.Balance, 800);
        }


        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        public void TestOverdraft()
        {
            BankAccount testAccount = new BankAccount("Hello", "Test", -100);
        }

        [TestMethod]
        public void TestTransactionHistory()
        {
            BankAccount testAccount = new BankAccount("Hello", "Test", 1000);
            testAccount.Deposit(1000);
            testAccount.Withdraw(100);
            testAccount.Withdraw(100);
            testAccount.Deposit(1000);
            testAccount.Withdraw(100);
            testAccount.Withdraw(100);

            Assert.AreEqual(testAccount.Balance, 1600);
            CollectionAssert.AreEqual(testAccount.TransactionHistory, new List<double>() {1000, -100, -100, 1000, -100, -100});

        }
    }
}
