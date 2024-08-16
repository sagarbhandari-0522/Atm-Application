// See https://aka.ms/new-console-template for more information
using Atm_Application.UI;
using System;

    class AtmApplication
    {
        public static void Main()
        {
            AppScreen.WelcomeMessage();
        long cardNumber = Validator.Converter<long>("enter card number");
        Console.WriteLine(cardNumber);
            // name=Utility.GetUserInput("your name");
            //Console.WriteLine($"Your name is {name}");
            //bool isValid = Validator.IsValid<long>(name);


        }
    }


