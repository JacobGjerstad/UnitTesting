﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountWithTests
{
    public class BankAccount
    {
        private string accountNumber;

        public BankAccount(string accNum) : this(accNum, 0.00)
        {
        }

        public BankAccount(string accNum, double initialBal)
        {
            AccountNumber = accNum;
            Balance = initialBal;
        }

        public string AccountNumber 
        {
            get 
            { 
                return accountNumber; 
            }
            set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Account number can't be null or have whitespace");

                }
                accountNumber = value; 
            }
        }

        public string Owner { get; set; }

        public double Balance { get; private set; }

        /// <summary>
        /// Deposits a positive amount of money into the account
        /// and returns the new Balance
        /// <see cref="Balance""/>
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when amt is 0 or less</exception>
        /// <param name="amt">Amount of money being deposited into the account</param>
        public double Deposit(double amt)
        {
            if (amt <= 0)
            {
                throw new ArgumentException("You must deposit a positive amount");
            }
            Balance += amt;
            return Balance;
        }


        public void Withdraw(double amt)
        {
            if(amt >= Balance)
            {
                throw new ArgumentException("You must have a higher balance then the amount being withdrawed");
            }

            Balance -= amt;
        }
    }
}
