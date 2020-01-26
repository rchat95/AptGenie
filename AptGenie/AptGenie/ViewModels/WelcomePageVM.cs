using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AptGenie.ViewModels
{
    public class WelcomePageVM
    {
        public WelcomePageVM()
        {
            GoToSignInPage = new Command(async () =>
            {
                await Application.Current.MainPage.Navigation.PushAsync(new MainPage());

            });
        }

        public Command GoToSignInPage { get; }
    }
}
