/*
 * File Name: BankAccount.cs
 * Description: This file defines the BankAccount class with functionalities for deposits, withdrawals, and transaction history.
 * Name: Mohammed Aasim
 * Date Started: 07/12/2024
 * Date Last Modified: 12/14/2024
 */

using System;
using System.Collections.Generic;

namespace SimpleBankingApp
{
    public class BankAccount
    {
        // Property to store the name of the account holder
        public string AccountHolder { get; private set; }

        // Property to store the current balance of the account
        public decimal Balance { get; private set; }

        // List to track all transactions related to the account
        private List<string> _transactionHistory = new List<string>();

        // Constructor to initialize the account with an account holder's name and an optional initial deposit
        public BankAccount(string accountHolder, decimal initialDeposit = 0)
        {
            if (initialDeposit < 0)
                throw new ArgumentException("Initial deposit cannot be negative."); // Ensure deposit is valid

            AccountHolder = accountHolder ?? throw new ArgumentNullException(nameof(accountHolder), "Account holder name cannot be null."); // Ensure the name is not null
            Balance = initialDeposit;
            _transactionHistory.Add($"Account created for {AccountHolder} with initial deposit: {initialDeposit:C}"); // Log account creation
        }

        // Method to deposit money into the account
        public void Deposit(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Deposit amount must be positive."); // Ensure deposit amount is valid

            Balance += amount; // Add amount to the balance
            _transactionHistory.Add($"Deposited: {amount:C}"); // Log the transaction
        }

        // Method to withdraw money from the account
        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Withdraw amount must be positive."); // Ensure withdrawal amount is valid

            if (amount > Balance)
                throw new InvalidOperationException("Insufficient funds."); // Check for sufficient balance

            Balance -= amount; // Subtract amount from the balance
            _transactionHistory.Add($"Withdrew: {amount:C}"); // Log the transaction
        }

        // Method to retrieve the transaction history of the account
        public IEnumerable<string> GetTransactionHistory()
        {
            return _transactionHistory; // Return the list of transactions
        }

        // Method to provide a summary of the account details as a string
        public override string ToString()
        {
            return $"Account Holder: {AccountHolder}\nBalance: {Balance:C}"; // Format and return account details
        }
    }
}
