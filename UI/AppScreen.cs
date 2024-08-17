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
            for(int i=0;i<9;i++)
            {
                Console.Write("* ");
                Thread.Sleep(300);
            }
            Console.Clear();
        }
        internal static void WelcomeUser(string fullName)
        {
            Utility.PrintMessage($"Welcome to the ATM Application {fullName}");
        }
    } 
}
