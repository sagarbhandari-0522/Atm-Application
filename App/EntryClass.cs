using Atm_Application.Domain.Entities;
using Atm_Application.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atm_Application.App
{
    class EntryClass
    {
        public static void Main()
        {
            AppScreen.WelcomeMessage();
            AtmApplication atmAPP = new AtmApplication();
            atmAPP.currentUser = atmAPP.GetUserCardNumberAndCardPin();
            AppScreen.WelcomeUser(atmAPP.currentUser.FullName);
            AppScreen.DisplayAppMenu();
            atmAPP.getUserInput();





        }
    }
}
