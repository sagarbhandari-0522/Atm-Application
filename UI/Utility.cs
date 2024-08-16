using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atm_Application.UI
{
    public static class Utility
    {
        public static void PressEnterToContinue()
        {
            Console.WriteLine("Thankyou");
        }
        public static string GetUserInput( string prompt)
        {
            Console.WriteLine($"Please enter {prompt}");
            return Console.ReadLine();
        }
    }
}
