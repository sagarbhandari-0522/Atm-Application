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
using System.Runtime.CompilerServices;
using System.Diagnostics;

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
        internal static void WithDrawal(AtmApplication atmApp)
        {
            int counter = 0;
            while (counter<Max_Retry)
            {
                counter++;
                Utility.DisplayWithDrawalMenu();
                int withdrawal_amount=GetWithDrawalAmount();
                decimal account_balance = atmApp.currentUser.AccountBalance;
                
                if (withdrawal_amount == 0)
                {
                    HandleInvalidWithdrawalOptions();
                }
                else
                {
                    bool isSufficient = isBalanceSufficient(account_balance, withdrawal_amount);
                    if (isSufficient)
                    {
                        atmApp.currentUser.AccountBalance -= withdrawal_amount;
                        Utility.PrintMessage("Withdrawal Successfull", true);
                        Utility.PrintMessage("Generaing Summary");
                        AppScreen.AstricAnimation();
                        Console.Clear();
                        GenerateWithdrawalSummary(withdrawal_amount,atmApp.currentUser.AccountBalance);
                        return;
                    }
                    else
                    {
                        Utility.PrintMessage("You have insuffieicnt balance!!!\n Retry", false);
                    }
                }
            }
            Utility.PrintMessage("Maximum retry limit reached. Terminating process", false);
            AppScreen.AstricAnimation();
            Environment.Exit(0);
        }

        public static bool isBalanceSufficient(decimal account_balance, decimal withdrawal_ammount)
        {
            return account_balance >= withdrawal_ammount;

        }
        public static void HandleInvalidWithdrawalOptions()
        {
            Utility.PrintMessage("Please select the valid options [0-8]!!!", false);
            Utility.PressEnterToContinue();
          
        }
        public static void HandleInsufficientBalance()
        {
            Utility.PrintMessage("You have insuffieicnt balance!!!\n Retry", false);
            Utility.PressEnterToContinue();

        }

        public static int GetWithDrawalAmount()
        {
            int option = Validator.Converter<int>("Enter Option");
            int amount;
            switch(option)
            {
                case 1:
                    amount = 500;
                    break;
                case 2:
                    amount = 1000;
                    break;
                case 3:
                    amount = 1500;
                    break;
                case 4:
                    amount = 2000;
                    break;
                case 5:
                    amount = 2500;
                    break;
                case 6:
                    amount=5000;
                    break;
                case 7:
                    amount = 10000;
                    break;
                case 8:
                   amount=20000;
                    break;
                case 0:
                    amount = GetUserInputWithDrawalAmount();
                    break;
                default:
                    amount = 0;
                    break;
            }
            return amount;
        }
        public static int GetUserInputWithDrawalAmount()
        {
            int counter = 0;
            while (true)
            {
                counter++;
                int amount = Validator.Converter<int>("amount to be withdrawal");
                if (amount % 500 == 0 && amount > 0)
                {
                    return amount;
                }

                else if (counter > Max_Retry)
                {
                    Utility.PrintMessage("Sorry you have multiple invalid input \n Terminating the program");
                    AppScreen.AstricAnimation();
                    Environment.Exit(0);
                }
                Utility.PrintMessage($"Please enter valid input\n Multiple of 500 Thank You! \n{Max_Retry - counter} times remaining",false);
            }

        }

        public static void GenerateWithdrawalSummary(int amount, decimal account_balance )
        {
            Utility.PrintMessage($"You have successfully withdrawan {amount} \n Your remaining balance is {account_balance}\nThank You for using our System.",true);
        }

        
        
    }
}
