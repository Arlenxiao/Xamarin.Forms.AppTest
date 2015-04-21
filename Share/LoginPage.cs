using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Share
{
    public class LoginPage : ContentPage
    {
        public LoginPage(IPageManager pm)
        {
            var layout = new StackLayout();

            var logo = new Image
            {
                Aspect = Aspect.AspectFit,
                Source = ImageSource.FromFile("Logo.png"),

            };
            var username = new Entry { Placeholder = "用户名", Style = ShareStyle.entryStyle };
            var password = new Entry { Placeholder = "密码", IsPassword = true, Style = ShareStyle.entryStyle };
            var buttonLogin = new Button { Text = "登录", Style = ShareStyle.buttonStyle };
            var buttonbg = new Button { Text = "默认背景", Style = ShareStyle.buttonStyle };
            var buttonbg_bule = new Button { Text = "蓝色背景", Style = ShareStyle.buttonStyle };

            layout.Children.Add(logo);
            layout.Children.Add(username);
            layout.Children.Add(password);
            layout.Children.Add(buttonLogin);
            layout.Children.Add(buttonbg);
            layout.Children.Add(buttonbg_bule);
   
        
            buttonLogin.Clicked += (s, e) =>
            {
                pm.NavigationPage(new Share(pm));
            };
            username.Unfocused += (s, e) =>
            {
                DisplayAlert("失去焦点", username.Text, "确定");
            };
            password.Unfocused += (s, e) =>
            {
                DisplayAlert("失去焦点", password.Text, "确定");
            };
           

            var backgroundImage = new Image
            {
                Aspect = Aspect.AspectFill,
                Source = ImageSource.FromFile("bg.png")
            };

            buttonbg.Clicked += (s, e) =>
            {
                backgroundImage.Source = ImageSource.FromFile("bg.png");
            };
            buttonbg_bule.Clicked += (s, e) =>
            {
                backgroundImage.Source = ImageSource.FromFile("bg_bule.png");
            };

            var layoutLink = new StackLayout { Orientation = StackOrientation.Horizontal, VerticalOptions = LayoutOptions.End, HorizontalOptions = LayoutOptions.Start};

            var register = new Label { Text = "注册", Style = ShareStyle.lableStyle,  };
            var wswl = new Label { Text = "无声物联", Style = ShareStyle.lableStyle,};
            layoutLink.Children.Add(register);
            layoutLink.Children.Add(wswl);

            var layout_main = new StackLayout();
            layout_main.Children.Add(layout);
            layout_main.Children.Add(layoutLink);

            var relativeLayout = new RelativeLayout();
            relativeLayout.Children.Add(backgroundImage, Constraint.Constant(0), Constraint.Constant(0),
                Constraint.RelativeToParent((parent) => { return parent.Width; }),
                Constraint.RelativeToParent((parent) => { return parent.Height; })
                );

            relativeLayout.Children.Add(layout_main, Constraint.Constant(0), Constraint.Constant(0),
                Constraint.RelativeToParent((parent) => { return parent.Width; }),
                Constraint.RelativeToParent((parent) => { return parent.Height; }));

          

            //relativeLayout.Children.Add(layoutLink, Constraint.Constant(0), Constraint.Constant(w),
            //   Constraint.RelativeToParent((parent) => { return parent.Width; }),
            //   Constraint.RelativeToParent((parent) => { return parent.Height; }));

            //var layoutAll = new StackLayout { Orientation = StackOrientation.Vertical, VerticalOptions = LayoutOptions.End, HorizontalOptions = LayoutOptions.Center };

            //layoutAll.Children.Add(backgroundImage);
            //layoutAll.Children.Add(layout);
            //layoutAll.Children.Add(layoutLink);

            Content = relativeLayout;

            username.SetBinding(Entry.TextProperty, new Binding("Username"));
            password.SetBinding(Entry.TextProperty, new Binding("Password"));
            buttonLogin.SetBinding(Button.CommandProperty, new Binding("LoginCommand"));

        }

    }
}
