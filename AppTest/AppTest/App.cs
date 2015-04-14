using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Share;
using Xamarin.Forms;

namespace AppTest
{
    public class App : Application, IPageManager
    {
        public App()
        {
            //MainPage = new Share.Share();
            MainPage = new Share.LoginPage(this);
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        public void NavigationPage(Page page)
        {
            MainPage = page;
        }
    }
}
