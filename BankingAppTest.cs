/*
 * File Name: BankingAppTest.cs
 * Description: Unit tests for the BankAccount class, validating deposit, withdrawal, and transaction history functionalities.
 * Name: Mohammed Aasim
 * Date Started: 07/12/2024
 * Date Last Modified: 12/14/2024
 */

using NUnit.Framework; ,
using SimpleBankingApp;

namespace SimpleBankingApp.Test
{
    // This class contains unit tests for the BankAccount class.
    // Each test ensures that specific functionalities of the BankAccount class work as expected.
    public class BankingAppTest
    {
        // Test for account creation with valid initial deposit
        [Test]
        public void CreateAccount_ValidInitialDeposit_CreatesSuccessfully()
        {
            var account = new BankAccount("John Doe", 500);
            // Verify that the initial balance is correct
            Assert.AreEqual(500, account.Balance);
            // Verify that the account holder name is set correctly
            Assert.AreEqual("John Doe", account.AccountHolder);
        }

        // Test for depositing a positive amount
        [Test]
        public void Deposit_PositiveAmount_IncreasesBalance()
        {
            var account = new BankAccount("Jane Doe");
            // Perform deposit
            account.Deposit(100);
            // Verify the balance increases correctly
            Assert.AreEqual(100, account.Balance);
        }

        // Test for withdrawing a valid amount less than or equal to the balance
        [Test]
        public void Withdraw_PositiveAmount_DecreasesBalance()
        {
            var account = new BankAccount("Jane Doe", 200);
            // Perform withdrawal
            account.Withdraw(100);
            // Verify the balance decreases correctly
            Assert.AreEqual(100, account.Balance);
        }

        // Test for attempting to withdraw an amount greater than the balance
        [Test]
        public void Withdraw_ExceedingBalance_ThrowsException()
        {
            var account = new BankAccount("Jane Doe", 50);
            // Verify that an exception is thrown when withdrawal exceeds balance
            Assert.Throws<InvalidOperationException>(() => account.Withdraw(100));
        }

        // Test for transaction history functionality
        [Test]
        public void TransactionHistory_RecordsAllTransactions()
        {
            var account = new BankAccount("Jane Doe");
            // Perform multiple transactions
            account.Deposit(100);
            account.Withdraw(50);
            // Retrieve transaction history
            var history = account.GetTransactionHistory();
            // Verify the transaction history contains the correct number of records
            Assert.AreEqual(3, history.Count());
            // Verify specific transactions are recorded correctly
            StringAssert.Contains("Deposited: $100.00", history.ElementAt(1));
            StringAssert.Contains("Withdrew: $50.00", history.ElementAt(2));
        }
    }
}
