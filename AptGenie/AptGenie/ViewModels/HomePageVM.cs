using AptGenie.Services;
using AptGenie.Views;
using Plugin.FilePicker;
using Plugin.FilePicker.Abstractions;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AptGenie.ViewModels
{
    public class HomePageVM : INotifyPropertyChanged
    {
        public HomePageVM()
        {
            GoToAddAptPage = new Command(async () =>
            {
                await Application.Current.MainPage.Navigation.PushAsync(new AddAptPage());

            });
        }
        public Command GoToAddAptPage { get; }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
