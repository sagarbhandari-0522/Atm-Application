﻿// See https://aka.ms/new-console-template for more information

using System;
using Atm_Application.UI;
using Atm_Application.Domain.Entities;
namespace Atm_Application
{
    class AtmApplication
    {
        public List<UserAccount> Users;
        private UserAccount currentUser;
        public AtmApplication()
        {
            Users = new List<UserAccount>
            {
                new UserAccount("Sagar Bhandari", 123321, 12345.67m,123321, 123123,  0),
                new UserAccount("Sandhya Bhandari", 12344321, 12345.67m,12344321, 12341234, 0),
                new UserAccount("Sandhya Pandey", 1234554321, 12345.67m,1234554321, 1234512345, 0)
            };
        }
        public UserAccount GetUserCardNumberAndCardPin()
        {
            bool isCorrectLogin = false;
            const int maxAttempt = 3;
            int attemptCounter = 0;
            
            while (attemptCounter<maxAttempt)
            {
                attemptCounter++;
                currentUser = AppScreen.UserLoginForm();
                AppScreen.LoginProcess();
                isCorrectLogin = CheckUsersCredential(currentUser, this.Users);
                if(isCorrectLogin==true)
                {
                    foreach (var user in this.Users)
                    {
                        if (user.CardNumber == currentUser.CardNumber)
                        {
                            return user;
                        }
                    }
                }
                else
                {
                    Utility.PrintMessage($"You enter wrong Credentials.\n{maxAttempt-attemptCounter} times remaining",false);
                }
                
            }
            Atm_Application.App.Utility.BlockAccount(currentUser.CardNumber,this.Users);
            Utility.TerminationOfProgram("You have attempted 3 tries your account is locked");
            return currentUser;
            
        }
        public bool CheckUsersCredential(UserAccount currentUser,List<UserAccount> users)
        {
            foreach (var user in users)
            {

                if (user.CardPin == currentUser.CardPin && user.CardNumber == currentUser.CardNumber)
                {
                    if(user.IsLocked==false)
                    {
                        return true;

                    }
                    else
                    {
                        Utility.TerminationOfProgram($"Your account is previously locked so that please Visit near by bank counter");

                    }
                }


            }
            return false;

               
        }
    }


}



