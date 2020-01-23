using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AptGenie.ViewModels
{
    public class SignInPageVM
    {
        public SignInPageVM()
        {
            TestCommand = new Command(() =>
            {
                Application.Current.MainPage.DisplayAlert("Alert", "Button clicked", "OK");
            });
        }

        public Command TestCommand { get; }
    }
}
