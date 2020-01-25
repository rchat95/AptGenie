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
            TestCommand = new Command(() =>
            {
                Application.Current.MainPage.DisplayAlert("Alert", "Your email is " + emailID + " and your password is " + password, "OK");
                
                
            });
        }

        

        public Command TestCommand { get; }

        

        public string emailID { get; set; }

        public string password { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
