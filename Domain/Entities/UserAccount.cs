using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atm_Application.Domain.Entities
{
    public class UserAccount
    {
        public static int Counter = 0;
        public int Id { get; set; }
        public string FullName { get; set; }
        public long AccountNumber { get; set; }
        public decimal AccountBalance { get; set; }
        public long CardNumber { get; set; }
        public int TotalLogin { get; set; }
        public bool IsLocked { get; set; }
        public int CardPin { get; set; }
        public UserAccount() { }
            
        public UserAccount(string fullName, long acc_number, decimal acc_balance, long card_number, int card_pin, int total_login, bool is_locked = false)
        {
            Counter++;
            Id = Counter;
            FullName = fullName;
            AccountNumber = acc_number;
            AccountBalance = acc_balance;
            CardNumber = card_number;
            CardPin = card_pin;
            TotalLogin = total_login;
            IsLocked = is_locked;

        }
    }
}
