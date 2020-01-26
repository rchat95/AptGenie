using AptGenie.Services;
using AptGenie.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace AptGenie.ViewModels
{
    public class SignUpPageVM : INotifyPropertyChanged
    {
        public SignUpPageVM()
        {
            SignUpCommand = new Command(() =>
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
                    if (phonenum.Length != 10 && phonenum.Length != 0)
                    {
                        Application.Current.MainPage.DisplayAlert("Alert", "Invalid phone number", "OK");
                        return;
                    }

                    #endregion
                    var token = DependencyService.Get<IFirebaseAuthenticator>().CreateWithEmailPassword(emailID, password);

                    if (token != null)
                    {
                        Application.Current.MainPage.Navigation.PushAsync(new HomePage());
                    }

                }
                catch (Exception ex)
                {

                }

            });

        }

        public Command SignUpCommand { get; }

        public string userName { get; set; }
        public string emailID { get; set; }
        public string password { get; set; }
        public string phonenum { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
