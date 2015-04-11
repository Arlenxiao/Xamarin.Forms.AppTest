using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Share
{
    public class Share : TabbedPage
    {
        public Share()
        {



            //var button = new Button
            //{
            //    Text = "来点我啊!",
            //    VerticalOptions = LayoutOptions.CenterAndExpand,
            //    HorizontalOptions = LayoutOptions.CenterAndExpand,
            //};

            //int clicked = 0;
            //button.Clicked += (s, e) => button.Text = "点就点,谁怕谁: " + clicked++;

            //Content = button;
            //Content = new Label { Text="test"};

            #region Login in

            var txt_user = new Entry { Placeholder = "账号" };
            var txt_password = new Entry { Placeholder = "密码", IsPassword = true };
            var btn_login = new Button
            {
                Text = "登录",
                TextColor = Color.White,
                BackgroundColor = Color.Blue
            };

            btn_login.Clicked += (s, e) => { txt_user.Text = "阿伦"; txt_password.Text = "123456"; };

            var profilePage = new ContentPage
            {
                Title = "登录",
                Content = new StackLayout
                {
                    Spacing = 20,
                    Padding = 50,
                    VerticalOptions = LayoutOptions.Center,
                    Children = { txt_user, txt_password, btn_login }
                }
            };

            #endregion

            #region setting

            var settingPage = new ContentPage
            {
                Title = "设置",
                Content = new StackLayout
                {
                    Children = { 
                        new Button
                        {
                            Text = "来点我啊!",
                            VerticalOptions = LayoutOptions.CenterAndExpand,
                            HorizontalOptions = LayoutOptions.CenterAndExpand,
                        }
                    }
                }
            };

            #endregion

            this.Children.Add(profilePage);
            this.Children.Add(settingPage);

        }




    }
}
