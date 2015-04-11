using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Share
{
    public class Share : TabbedPage
    {

        Entry txt_user { get; set; }
        Entry txt_password { get; set; }

        Button btn_login { get; set; }

        Button btn_test { get; set; }

        Int32 count = 1;

        public Share()
        {
            var img = new Image()
            {
                Source = "http://s.qdcdn.com/cl/12285817,800,450.jpg",
                VerticalOptions = LayoutOptions.Center,
                //Scale = 2,
                AnchorY = 0,
            };

            #region Login in

            txt_user = new Entry { Placeholder = "账号" };
            txt_password = new Entry { Placeholder = "密码", IsPassword = true };
            btn_login = new Button
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
                    Children = { txt_user, txt_password, btn_login },                   
                }
            };

            #endregion

            #region setting

            btn_test = new Button
            {
                Text = "来点我啊!",
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };
            btn_test.Clicked += (s, e) =>
            {
                btn_test.Text = "点击我的次数:" + count++;
            };

            var settingPage = new ContentPage
            {
                Title = "设置",
                Content = new StackLayout
                {
                    Children =
                    {
                      img,  btn_test,
                    }
                }
            };

            #endregion

           

            this.Children.Add(profilePage);
            this.Children.Add(settingPage);
            //this.Children.Add(img);
            this.PagesChanged += (s, e) =>
            {
                txt_user.Text = "";
                txt_password.Text = "";
                count = 1;
            };
            //this.BackgroundImage = "http://demo.sc.chinaz.com/Files/pic/icons/5821/0.png";
        }




    }
}
