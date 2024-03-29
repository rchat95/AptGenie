﻿using AptGenie.Services;
using AptGenie.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace AptGenie.ViewModels
{
    public class SignInPageVM : INotifyPropertyChanged
    {
       
        public SignInPageVM()
        {
            SignInCommand = new Command(() =>
            {
                try
                {
                    #region Field validations
                    if (!emailID.Contains("@"))
                    {
                        Application.Current.MainPage.DisplayAlert("Alert", "Invalid Email ID", "OK");
                        return;
                    }
                    if (emailID.Trim() == "")
                    {
                        Application.Current.MainPage.DisplayAlert("Alert", "Email ID cannot be blank", "OK");
                        return;
                    }
                    if (password.Trim() == "")
                    {
                        Application.Current.MainPage.DisplayAlert("Alert", "Password cannot be blank", "OK");
                        return;
                    } 
                    #endregion
                    DependencyService.Get<IFirebaseAuthenticator>().LoginWithEmailPassword(emailID, password);
                    
                }
                catch (Exception ex)
                {
                    
                }         

            });

            GoToSignUpPage = new Command(() =>
            {
                Application.Current.MainPage.Navigation.PushAsync(new SignUpPage());
            });
        }
        public Command SignInCommand { get; }
        public Command GoToSignUpPage { get; }
        public string emailID { get; set; }
        public string password { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}