using Atm_Application.App;
using Atm_Application.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atm_Application.UI 
{
    public static class AppScreen
    {
        internal static void WelcomeMessage()
        {
            Console.Clear();
            Console.Title = "MY ATM APPLICATION";
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n\n------------Welcome to My ATM Application-------\n\n");
            Console.WriteLine("Please insert your ATM card");
            Console.WriteLine("Note: This machine will accept and validate a physical atm card");
            Utility.PressEnterToContinue();
        }
        internal static UserAccount UserLoginForm()
        {
            UserAccount inputUser = new UserAccount();
            inputUser.CardNumber = Validator.Converter<long>("Enter Card Number");
            inputUser.CardPin =Convert.ToInt32(Utility.ChangeSecretToAstric("Enter Card Pin"));
            return inputUser;
        }
        public static void LoginProcess()
        {
            Console.WriteLine("\nChecking Card Number and PIN");
            AstricAnimation();
            Console.Clear();
        }
        public static void LogOut()
        {
            Console.WriteLine("Logging Out");
            AstricAnimation();
            Console.WriteLine("You Have Successfully Log Out");
            Console.WriteLine("Press Enter to Restart or Any other key to exit");
            var key=Console.ReadKey(intercept:true);
            if(key.Key==ConsoleKey.Enter)
            {
                EntryClass.Main();
            }
            else
            {
                Environment.Exit(0);
            }
        }
        internal static void WelcomeUser(string fullName)
        {
            Utility.PrintMessage($"Welcome to the ATM Application {fullName}");
        }
        internal static void DisplayAppMenu()
        {
            Console.WriteLine("-------My ATM App Menu-------");
            Console.WriteLine(":                            :");
            Console.WriteLine("1.  Account Balance          :");
            Console.WriteLine("2.  Cash Deposit             :");
            Console.WriteLine("3.  Withdrawal               :");
            Console.WriteLine("4.  Transfer                 :");
            Console.WriteLine("5.  Transactions             :");
            Console.WriteLine("6.  Logout                   :");
        }
        public static void CheckBalance(UserAccount user)
        {
            Console.WriteLine("Balance is ");
        }
        public static void AstricAnimation()
        {
            for (int i = 0; i < 7; i++)
            {
                Console.Write("* ");
                Thread.Sleep(200);
            }
        }
    } 
}
