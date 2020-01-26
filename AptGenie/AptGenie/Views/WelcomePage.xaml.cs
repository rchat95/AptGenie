using AptGenie.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AptGenie.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WelcomePage : ContentPage
    {
        public WelcomePage()
        {
            this.BackgroundColor = Color.FromHex("006ebd");
            InitializeComponent();
            BindingContext = new WelcomePageVM();

        }
    }
}