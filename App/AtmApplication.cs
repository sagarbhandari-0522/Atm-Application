// See https://aka.ms/new-console-template for more information

using System;
using Atm_Application.UI;
using Atm_Application.Domain.Entities;
namespace Atm_Application
{
    class AtmApplication
    {
        public static void Main()
        {
            AppScreen.WelcomeMessage();
            InitializeData.Initialize();
            long cardNumber = Validator.Converter<long>("Enter Card Number");
            Utility.PrintMessage($"Your card number is {cardNumber}", true);


        }
    }


}



