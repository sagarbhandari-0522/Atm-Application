using Atm_Application.Domain.Entities;
using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atm_Application.UI;
using System.Transactions;
using System.Security.Principal;

namespace Atm_Application.App
{
    public static class AppUtility
    {
        public const int Max_Retry = 3;

        public static void BlockAccount(long cardNumber, List<UserAccount> users)
        {
            foreach (var user in users)
            {
                if(user.CardNumber==cardNumber)
                {
                    user.IsLocked = true;
                }
            }
        }

        internal static void DepositAmount(AtmApplication atmApp)
        {
            Utility.PrintMessage("Only multiple of 500 and 1000 is allowed.", true);
            long amount =GetAmountToDeposit();
           
            Console.WriteLine("Checking and Counting bank notes");
            AppScreen.AstricAnimation();
            GenerateSummary(amount);
            bool isConfirmed = Utility.MakeConfirmation("Do you confirm it: Y/N");
            if (isConfirmed)
            {
                atmApp.currentUser.AccountBalance += amount;
                Utility.PrintMessage($"Deposit successful! \n Your new balance is {atmApp.currentUser.AccountBalance}",true);
            }
            else
            {
                Utility.PrintMessage("Cancelation of process and return to Main Menu");
                AppScreen.AstricAnimation();
                atmApp.getUserInput();
            }
        }
        public static void GenerateSummary(long amount)
        {
            Console.Clear();
            Console.WriteLine("Summary");
            Console.WriteLine("-----------");
            CalculateDenominations( amount, out int numberOfThousands, out int numberOfFiveHundreads);
            Console.WriteLine($"{Utility.CurrencyCode()} 1000 X {numberOfThousands} = {1000 * numberOfThousands}");
            Console.WriteLine($"{Utility.CurrencyCode()} 500 X {numberOfFiveHundreads} = {500 * numberOfFiveHundreads}");
        }
        public static void CalculateDenominations( long amount,out int numberOfThousands, out int numberOfFiveHundreads)
        {
            numberOfThousands = (int)amount / 1000;
            numberOfFiveHundreads = (int)(amount % 1000)/500;
        }
     
        public static long GetAmountToDeposit()
        {
            int counter = 0;
            while (true)
            {
                counter++;
                long amount = Validator.Converter<long>("Enter amount");// check input validation
                if (amount % 500 == 0 && amount >0)
                {
                   return amount;
                }
                else if (counter > Max_Retry)
                {
                    Utility.PrintMessage("Sorry you have multiple invalid input \n Terminating the program");
                    AppScreen.AstricAnimation();
                    Environment.Exit(0);
                }
                else
                {
                  
                    Utility.PrintMessage($"Please enter the multiple of 500. Thank You!\n {Max_Retry-counter} times remaining", false);
                }

            }
        }
        
        
    }
}
