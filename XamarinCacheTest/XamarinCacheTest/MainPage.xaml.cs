using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinCacheTest.Helpers;

namespace XamarinCacheTest
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            UsName.Text = Settings.UserNameSettings;
            UsPwd.Text = Settings.UsPwdSettings;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Settings.UserNameSettings=UsName.Text;
            Settings.UsPwdSettings= UsPwd.Text;
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            DisplayAlert("Message","用户名： "+Settings.UserNameSettings+" 密码： "+Settings.UsPwdSettings,"OK");
        }
    }
}
