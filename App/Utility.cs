using Atm_Application.Domain.Entities;
using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atm_Application.App
{
    public static class Utility
    {
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
        
    }
}
