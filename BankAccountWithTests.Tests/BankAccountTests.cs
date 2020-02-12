using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccountWithTests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountWithTests.Tests
{
    [TestClass()]
    public class BankAccountTests
    {
        [DataRow("123")]
        [DataRow("A")]
        [DataRow("1234567890")]
        [DataRow("ABC123")]
        [DataRow("ABC123#!@")]
        [DataRow("☺")]
        [TestMethod]
        public void Constructor_ValidAccNum_SetsAccountNumber(string accNum)
        {
            // Arrange => Act
            BankAccount acc = new BankAccount(accNum);

            // Assert
            Assert.AreEqual(accNum, acc.AccountNumber);


        }

        [DataRow(null)]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow("        ")]
        [TestMethod]
        public void Constructor_InvalidAccNum_ThrowsArgumentException(string accNum)
        {
            // Arrange => Act => Assert
            Assert.ThrowsException<ArgumentException>(() => new BankAccount(accNum));
        }

        [TestMethod()]
        public void Deposit_PositiveValue_AddsToBalance()
        {
            // Arrange - create objects in variables
            BankAccount acc = new BankAccount("123");
            double depositAmount = 100.0;
            double expectedBalance = 100.0;

            // Act - Call method under test
            acc.Deposit(depositAmount);


            // Assert
            Assert.AreEqual(expectedBalance, acc.Balance);
        }

        [TestMethod]
        public void Deposit_PositiveAmountWithCents_AddsToBalance()
        {
            // Arrange
            BankAccount acc = new BankAccount("123");
            double depositAmount = 10.55;
            double expectedBalance = 10.55;

            // Act
            acc.Deposit(depositAmount);

            // Assert
            Assert.AreEqual(expectedBalance, acc.Balance);
        }

        [DataRow(.01)]
        [DataRow(9999999.99)]
        [DataRow(100.99)]
        [DataRow(100)]
        [TestMethod]
        public void Deposit_PositiveAmount_ReturnsUpdatedBalance(double depositAmt)
        {
            // Arrange
            BankAccount acc = new BankAccount("123");
            double initialBalance = 0;
            double expectedBalance = initialBalance + depositAmt;

            // Act
            double returnedBalance = acc.Deposit(depositAmt);

            // Assert
            Assert.AreEqual(expectedBalance, returnedBalance);
            // Assert.AreEqual(expectedBalance, acc.Balance);

        }

        [DataRow(-.01)]
        [DataRow(-9999999.99)]
        [DataRow(-100.99)]
        [DataRow(-100)]
        [DataRow(0)]
        [DataRow(-1)]
        [TestMethod]
        [TestCategory("Deposit")]
        [Priority(2)]
        public void Deposit_NegativeAmount_ThrowsArgumentException(double depositAmt)
        {
            // Arrange
            BankAccount acc = new BankAccount("123");

            // Assert => Act
            Assert.ThrowsException<ArgumentException>(() => acc.Deposit(depositAmt));

        }

        [TestMethod]
        [TestCategory("Deposit")]
        [Priority(1)]
        public void Deposit_MultiplePositiveDeposits_AddsToBalance()
        {
            // Arrange
            BankAccount acc = new BankAccount("123");
            double amount1 = 100;
            double amount2 = 50;

            // Act
            acc.Deposit(amount1);
            Assert.AreEqual(amount1, acc.Balance);

            acc.Deposit(amount2);
            Assert.AreEqual(amount1 + amount2, acc.Balance);
        }

        [TestMethod]
        public void Withdraw_PositiveAmount_ReducesBalance()
        {
            // Arrange
            string accNum = "123";
            double initialBal = 100;
            var acc = new BankAccount(accNum, initialBal);

            double withdrawAmt = 25.50;

            double expectedBalance = initialBal - withdrawAmt;

            // Act
            acc.Withdraw(withdrawAmt);

            // Assert
            Assert.AreEqual(expectedBalance, acc.Balance);
        }

        [TestMethod]
        public void Withdraw_PositiveAmount_ThrowsArgumentException()
        {
            // Arrange
            string accNum = "123";
            double initialBal = 100;
            var acc = new BankAccount(accNum, initialBal);

            double withdrawAmt = 125.0;

            double expectedBalance = initialBal - withdrawAmt;

            // Act
            Assert.ThrowsException<ArgumentException>(() => acc.Withdraw(withdrawAmt));
        }
    }
}