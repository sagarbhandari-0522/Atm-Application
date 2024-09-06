using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Atm_Application.UI
{
    public static class Validator
    {
        public static T Converter<T>(string prompt)
        {
            bool valid = false;
            while(!valid)
            {
                try
                {
                    string userInput = Utility.GetUserInput(prompt);
                    return (T)Convert.ChangeType(userInput, typeof(T));
                }
                catch
                {
                    Utility.PrintMessage("Invalid Input", false);
                }
            }
            return default;
          
        }    

    }
}
