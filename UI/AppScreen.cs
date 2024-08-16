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
    } 
}
