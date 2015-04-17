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
            //var buttonRegister = new Button { Text = "注册", Style = ShareStyle.buttonStyle };

            layout.Children.Add(logo);
            layout.Children.Add(username);
            layout.Children.Add(password);
            layout.Children.Add(buttonLogin);
            //layout.Children.Add(buttonRegister);

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

            var layoutLink = new StackLayout { Orientation = StackOrientation.Horizontal, VerticalOptions = LayoutOptions.End, HorizontalOptions = LayoutOptions.End};

            var register = new Label { Text = "注册", Style = ShareStyle.lableStyle };
            var wswl = new Label { Text = "无声物联", Style = ShareStyle.lableStyle };
            layoutLink.Children.Add(register);
            layoutLink.Children.Add(wswl);

            //layout.Children.Add(layoutLink);

            var relativeLayout = new RelativeLayout();
            relativeLayout.Children.Add(backgroundImage, Constraint.Constant(0), Constraint.Constant(0),
                Constraint.RelativeToParent((parent) => { return parent.Width; }),
                Constraint.RelativeToParent((parent) => { return parent.Height; })
                );

            relativeLayout.Children.Add(layout, Constraint.Constant(0), Constraint.Constant(0),
                Constraint.RelativeToParent((parent) => { return parent.Width; }),
                Constraint.RelativeToParent((parent) => { return parent.Height; }));

            relativeLayout.Children.Add(layoutLink, Constraint.Constant(0), Constraint.Constant(0),
               Constraint.RelativeToParent((parent) => { return parent.Width; }),
               Constraint.RelativeToParent((parent) => { return parent.Height; }));

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
