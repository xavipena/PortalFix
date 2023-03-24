using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using MvvmHelpers;

namespace PortalFix.ViewModels
{
    public class LoginViewModel : ObservableObject
    {
        private static readonly string secret = "12345";
        public Action DisplayInvalidLoginPrompt;
        private bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                SetProperty(ref isBusy, value);
            }
        }
        private bool isNotLogged = true;
        public bool IsNotLogged
        {
            get { return isNotLogged;  }
            set 
            {
                SetProperty(ref isNotLogged, value);
            }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                SetProperty(ref password, value);
            }
        }
        private string welcomeText;
        public string WelcomeText
        {
            get { return welcomeText; }
            set
            {
                SetProperty(ref welcomeText, value);
            }
        }
        public LoginViewModel()
        {
        }
        public bool ValidCredential()
        {
            if (!AreCredentialsCorrect())
            {
                DisplayInvalidLoginPrompt();
                return false;
            }
            isBusy = true;
            isNotLogged = false;
            return true;
        }

        public bool AreCredentialsCorrect()
        {
            return password == secret;
        }
    }
}
