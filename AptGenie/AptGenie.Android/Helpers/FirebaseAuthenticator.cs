using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AptGenie.Droid.Helpers;
using AptGenie.Services;
using AptGenie.Views;
using Firebase;
using Firebase.Auth;

[assembly: Xamarin.Forms.Dependency(typeof(FirebaseAuthenticator))]
namespace AptGenie.Droid.Helpers
{
    public class FirebaseAuthenticator : IFirebaseAuthenticator
    {
        //Method for sign-in
        public async Task<string> LoginWithEmailPassword(string email, string password)
        {
            try
            {
                var user = await FirebaseAuth.Instance.SignInWithEmailAndPasswordAsync(email, password);
                var token = await user.User.GetIdTokenAsync(false);

                //await App.Current.MainPage.DisplayAlert("Login Success", "Redirecting to homepage...", "OK");
                await App.Current.MainPage.Navigation.PushAsync(new HomePage());
                return token.Token;
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Login Error", "Incorrect username or password", "OK");
                return null;
            }

        }

        //Method for sign-up
        public async Task<string> CreateWithEmailPassword(string email, string password)
        {
            try
            {
                var user = await FirebaseAuth.Instance.CreateUserWithEmailAndPasswordAsync(email, password);
                var token = await user.User.GetIdTokenAsync(false);

                //await App.Current.MainPage.DisplayAlert("Signup Success", "Redirecting to set filters page...", "OK");
                /*await App.Current.MainPage.Navigation.PushAsync(new HomePage())*/;
                return token.Token;
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Signup Error", "There was an error signing up", "OK");
                return null;
            }

        }


    }
}