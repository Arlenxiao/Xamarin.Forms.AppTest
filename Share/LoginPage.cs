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
            var layout = new StackLayout { Padding = 10 };

           
            var logo = new Image
            {
                //Aspect = Aspect.AspectFill,
                Source = ImageSource.FromFile("Logo.png"),
                //Padding = 20 
            };

            layout.Children.Add(logo);

            var username = new Entry { Placeholder = "用户名" };
            layout.Children.Add(username);

            var password = new Entry { Placeholder = "密码", IsPassword = true, };
            layout.Children.Add(password);

            var buttonLogin = new Button { Text = "登录", TextColor = Color.White };
            var buttonRegister = new Button { Text = "注册", TextColor = Color.White };
            layout.Children.Add(buttonLogin);
            layout.Children.Add(buttonRegister);

            buttonLogin.Clicked += (s, e) =>
            {
                pm.NavigationPage(new Share(pm));
            };
            
            var backgroundImage = new Image
            {
                Aspect = Aspect.AspectFill,
                Source = ImageSource.FromFile("bg.png")
            };

            var relativeLayout = new RelativeLayout();
            relativeLayout.Children.Add(backgroundImage, Constraint.Constant(0), Constraint.Constant(0),
                Constraint.RelativeToParent((parent) => { return parent.Width; }),
                Constraint.RelativeToParent((parent) => { return parent.Height; })
                );

            relativeLayout.Children.Add(layout, Constraint.Constant(0), Constraint.Constant(0),
                Constraint.RelativeToParent((parent) => { return parent.Width; }),
                Constraint.RelativeToParent((parent) => { return parent.Height; }));

            Content = relativeLayout;

            username.SetBinding(Entry.TextProperty, new Binding("Username"));
            password.SetBinding(Entry.TextProperty, new Binding("Password"));
            buttonLogin.SetBinding(Button.CommandProperty, new Binding("LoginCommand"));
            buttonRegister.SetBinding(Button.CommandProperty, new Binding("RegisterCommand"));

        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            var aboutItem = new ToolbarItem { Name = "关于我们", BindingContext = BindingContext };
            aboutItem.SetBinding(ToolbarItem.CommandProperty, new Binding("ShowAboutCommand"));

            ToolbarItems.Add(aboutItem);
        }
    }
}
