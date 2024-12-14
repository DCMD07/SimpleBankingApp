/*
 * File Name: Program.cs
 * Description: This is a entry point for the Simple Banking App, providing us with an interactive console interface for banking operations.
 * Name: Mohammed Aasim
 * Date Started: 07/12/2024
 * Date Last Modified: 12/14/2024
 */

using System;

namespace SimpleBankingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Welcome message for the user
            Console.WriteLine("Welcome to the Simple Banking App!");

            // Prompt the user to enter the account holder's name
            Console.Write("Enter account holder's name: ");
            string name = Console.ReadLine();

            // Prompt the user to enter the initial deposit
            Console.Write("Enter initial deposit: ");
            decimal initialDeposit = decimal.Parse(Console.ReadLine());

            // Create a new BankAccount instance
            var account = new BankAccount(name, initialDeposit);
            Console.WriteLine("Account created successfully!");
            Console.WriteLine(account); // Display account details

            // Start the menu loop
            while (true)
            {
                // Display the menu options
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Deposit");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. Show Transaction History");
                Console.WriteLine("4. Exit");

                // Prompt the user to choose an option
                Console.Write("Choose an option: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        // Handle deposit operation
                        Console.Write("Enter deposit amount: ");
                        decimal deposit = decimal.Parse(Console.ReadLine());
                        account.Deposit(deposit);
                        Console.WriteLine("Deposit successful!");
                        break;

                    case 2:
                        // Handle withdrawal operation
                        Console.Write("Enter withdrawal amount: ");
                        decimal withdraw = decimal.Parse(Console.ReadLine());
                        try
                        {
                            account.Withdraw(withdraw);
                            Console.WriteLine("Withdrawal successful!");
                        }
                        catch (Exception ex)
                        {
                            // Display an error message if withdrawal fails
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                        break;

                    case 3:
                        // Display the transaction history
                        Console.WriteLine("Transaction History:");
                        foreach (var transaction in account.GetTransactionHistory())
                        {
                            Console.WriteLine(transaction);
                        }
                        break;

                    case 4:
                        // Exit the application
                        Console.WriteLine("Exiting... Goodbye!");
                        return;

                    default:
                        // Handle invalid menu option
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }

                // Display the updated account summary after each operation
                Console.WriteLine(account);
            }
        }
    }
}
