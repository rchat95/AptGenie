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
    public partial class AddAptPage : ContentPage
    {
        public AddAptPage()
        {
            InitializeComponent();
            BindingContext = new AddAptVM();
        }
    }
}