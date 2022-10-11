using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class ATM
    {
        public List<Account> accounts {get; set;}

        //public List<Account> accounts = new List<Account>();

        public Account? currentAccount {get; set;}

        public ATM(List<Account> accounts)
        {
            this.accounts = accounts;
        }

        public ATM()
        {
            accounts = new List<Account>();
        }

        public void RegisterAccount()//string name, string password, int initialBalance
        {
            if (currentAccount == null)
            {
                Console.WriteLine("\nHello, to register, please type in a username:");
                string name = Console.ReadLine();

                Console.WriteLine($"\nThank you {name}. Please enter in a password:");
                string password1 = Console.ReadLine();

                Console.WriteLine($"\n{name}, enter your password again to confirm:");
                string password2 = Console.ReadLine();

                if (name == String.Empty || password1 == String.Empty || password2 == String.Empty)
                {
                    Console.WriteLine("You must enter a value for both username and password. Try again.");
                    return;
                }

                for (int i = 0; i < accounts.Count; i++)
                {
                    if (accounts[i].UserName.Contains(name))
                    {
                        Console.WriteLine("Username already exists. Please choose another name.");
                        return;
                    }
                }

                if (password1 == password2)
                {
                    Account a = new Account(name, password1);
                    accounts.Add(a);
                    Console.WriteLine($"\nCongratulations! You have successfully registered {a.UserName}.\nThank you for choosing \"Berger Bank!\" Please login to continue.");
                }

                else
                {
                    Console.WriteLine("\nPasswords do not match. Please try again.");
                }
            }

            else
            {
                Console.WriteLine("You must be logged out of your account to continue.");
            }
        }

        public void Login(string userName, string passWord)
        {
            for (int i = 0; i < accounts.Count; i++)
            {
                if (accounts[i]._userName == userName && accounts[i]._password == passWord)
                {
                    currentAccount = accounts[i];
                    Console.WriteLine($"\nSuccessful login: Hello {currentAccount._userName}!");
                    return;
                }
            }

            Console.WriteLine($"\nNo account found with username {userName} and password {passWord}.");
        }

        public void Logout()
        {
            if (currentAccount != null)
            {
                currentAccount = null;//why is this not becoming null??? I made it a nullable property with the "?"
                Console.WriteLine("\nSuccessfully logged out of account.");
            }

            else
            {
                Console.WriteLine("\nYou must be logged in to your account to perform this function.");
            }
        }

        public void CheckBalance()
        {
            if (currentAccount != null)
            {
                Console.WriteLine($"\n{currentAccount._userName} - your current balance is ${currentAccount.AccountBalance}");

                Console.WriteLine("How else may we assist you today?");
            }

            else
            {
                Console.WriteLine("\nPlease login to your account to view your balance.");
            }
        }

        public void Deposit(double depositAmount)
        {
            if (currentAccount != null)
            {
                currentAccount.AccountBalance += depositAmount;
                Console.WriteLine($"\nDeposit of ${depositAmount} accepted.\nYour current balance is ${currentAccount.AccountBalance}");
                Console.WriteLine("How else may we assist you today?");
            }

            else
            {
                Console.WriteLine("\nPlease login first.");
            }
        }

        public void Withdraw()//double withdrawAmount
        {
            if (currentAccount != null)
            {
                double withdrawalAmount;
                
                while (true)
                {
                    Console.WriteLine("\nHow much money would you like to withdraw from your account?");

                    try
                    {
                        withdrawalAmount = Math.Round(double.Parse(Console.ReadLine()), 2);
                        break;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        Console.WriteLine("CUSTOM MSG - Please enter a numeric value.");
                        //throw;//what does throw do here?
                    }
                }

                if (currentAccount.AccountBalance - withdrawalAmount > 0)
                {
                    currentAccount.AccountBalance -= withdrawalAmount; 
                    Console.WriteLine($"\nWithdrawal accepted. ${withdrawalAmount} taken from your account. Your current balance is ${currentAccount.AccountBalance}.");

                    Console.WriteLine("\nHow else may we assist you today?");
                }

                else
                {
                    Console.WriteLine("\nWithdrawal attempt failed. You must have a postive balance remaining.");
                }
            }

            else
            {
                Console.WriteLine("\nYou must be logged in to make a withdrawal.");
            }
        }
    }
}

/*What will the application do?
Create an ATM that logs a user into their account with the right password, and allows them to withdraw or deposit cash. 	
Allow the ATM to register a new account object by setting up a new name and password both of which should be private. 
Hint: The ATM will manage the accounts by delegating method calls to them

Build Specifications: Create 2 different classes: 
ATM - The ATM will act as a manager for the different accounts. The manager will need to track a list of accounts and which account is currently logged in. 
For methods the ATM will need the following: 
Register - Take in a name and password. Build a new account with that name and password and add it to the list of accounts. 
Login - this method will take in a username and password. First the method will check if there is a currently logged in user. If there is no logged in account, search the account list for an account that matches the name AND password. Once found, set that account to the current account. 
The following methods should only work if there’s a logged in account
Logout - Set the current account to null 
CheckBalance - Print the balance of the account 
Deposit - takes in an int and adds to the balance 
Withdraw - takes in an int and tries to subtract it from the balance. If the int is larger than the balance, do nothing and print an error message for the user 
Account - The account object will need to track the following: 
String Name 
String Password
Int Balance */