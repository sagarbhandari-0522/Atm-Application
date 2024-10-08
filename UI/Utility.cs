﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Atm_Application.UI
{
    public static class Utility
    {
        public static CultureInfo Culture = new CultureInfo("en-US");
        public static string ChangeSecretToAstric(string prompt)
        {
            PrintMessage(prompt, true);
            
            int attemptCounter = 0;
            const int maxAttempt= 3;
            
            while(attemptCounter<maxAttempt)
            {
                attemptCounter++;
                string input = readCardPin();
              
                if (input.Length >= 6)
                {
                    return input;
                }
                else
                {
                    PrintMessage($"\nPlease enter 6 digits valid pin, {maxAttempt-attemptCounter} times remaining", false);
                }
            }
            TerminationOfProgram("\nToo many incorrect attempts. Application terminated");
            return string.Empty;
        }
        public static void PressEnterToContinue()
        {
            Console.WriteLine("Press Enter to Continue and any other key to exit");
            var key = Console.ReadKey(intercept: true);
            if (key.Key == ConsoleKey.Enter)
            {
                Console.Clear();
            }
            else
            {
                Environment.Exit(0);
            }
        }

        public static string readCardPin()
        {
            StringBuilder input = new StringBuilder();
            while (true)
            {
                var userInput = Console.ReadKey(intercept: true);
                if (userInput.Key == ConsoleKey.Enter)
                {
                    break;
                }
                else if (userInput.Key == ConsoleKey.Backspace && input.Length > 0)
                {
                    Console.Write("\b \b");
                    input.Length -= 1;
                }
                else
                {
                    input.Append(userInput.KeyChar);
                    Console.Write("*");
                }

            }
            return input.ToString();
        }
       
        public static void TerminationOfProgram(string prompt)
        {
            PrintMessage(prompt, false);
            Thread.Sleep(2000);
            Environment.Exit(0);

        }
        public static string GetUserInput( string prompt)
        {
            Console.WriteLine($"Please enter {prompt}");
            return Console.ReadLine();
        }
        public static void PrintMessage(string message, bool success=true)
        {
            if (success)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(message);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(message);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        public static void DisplayBalance(decimal amount)
        {
            Console.OutputEncoding = Encoding.UTF8;
            var cultureInfo = (CultureInfo)CultureInfo.GetCultureInfo("en-NZ").Clone();
            string currencyCode = CurrencyCode();
            Console.WriteLine($"Your account balance is : {currencyCode}{amount}");

        }
        public static string CurrencyCode()
        {
           return (Culture.NumberFormat.CurrencySymbol);
        }

        public static bool MakeConfirmation(string prompt)
        {
            char confiramtionInput = Validator.Converter<char>(prompt);
            return (confiramtionInput == 'y' || confiramtionInput == 'Y' || confiramtionInput == '1');
        }

        public static void DisplayWithDrawalMenu()
        {
            Console.WriteLine($": 1. {Utility.CurrencyCode()} 500       5. {Utility.CurrencyCode()} 2500 ");
            Console.WriteLine($": 2. {Utility.CurrencyCode()} 1000      6. {Utility.CurrencyCode()} 5000 ");
            Console.WriteLine($": 3. {Utility.CurrencyCode()} 1500      7. {Utility.CurrencyCode()} 1000 ");
            Console.WriteLine($": 4. {Utility.CurrencyCode()} 2000      8. {Utility.CurrencyCode()} 20000 ");
            Console.WriteLine(":0. Other");

        }

    }
}
