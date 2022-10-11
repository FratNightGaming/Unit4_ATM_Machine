using Microsoft.Win32;
using System.Linq;
using System.Security.Principal;

namespace ATM
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to BERGER BANK! How may we assist you today?");

            ATM a = new ATM();

            bool goOn = true;
            while (goOn)
            {
                DisplayOptions();
                Console.WriteLine();
                
                string input = Console.ReadLine().ToUpper().Trim();

                switch (input)
                {
                    case "LOGIN":
                        Console.WriteLine("Please enter your username:");
                        string userName = Console.ReadLine();
                        Console.WriteLine("Please enter your password: ");
                        string pass = Console.ReadLine();
                        a.Login(userName, pass);
                        break;
                    
                    case "LOGOUT":
                        a.Logout();
                        break;
                    
                    case "BALANCE":
                        a.CheckBalance();
                        break;
                    
                    case "DEPOSIT":
                        Console.WriteLine("How much money would you like to deposit into your account?");
                        while (true)
                        {
                            try
                            {
                                double depositAmount = Math.Round(double.Parse(Console.ReadLine()), 2);
                                a.Deposit(depositAmount);
                                break;
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                                Console.WriteLine("Please enter a numeric value.");
                                //throw;
                            }
                        }
                        break;
                    
                    case "WITHDRAWAL":
                        a.Withdraw();
                        break;

                    case "REGISTER":
                        a.RegisterAccount();
                        break;

                    case "EXIT":
                        Console.WriteLine("Exiting program. Goodbye.");
                        goOn = false;
                        break;

                    default:
                        Console.WriteLine("No option registered. Try again:");
                        break;
                }
            }
        }

        public static void DisplayOptions()
        {
            Console.WriteLine($"\nLogin:\tenter \"login\" \nLogout:\tenter \"logout\"\nCheck Balance:\tenter \"balance\"\nDeposit: enter \"deposit\"\nWithdraw:\tenter \"withdrawal\"\nRegister new account:\tenter \"register\"\nExit program:\tenter \"exit\"");//why are the tabs bigger for some lines and smaller for others?
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
