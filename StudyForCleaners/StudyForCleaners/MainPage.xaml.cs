using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace StudyForCleaners
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            Label Header = new Label
            {
                Text = "Главная страница",
                FontSize = 40,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center,
                Margin = new Thickness(0, 0, 0, 0),
                TextColor = Color.Black 
            };
            Label label1 = new Label
            {
                Text = "Добро пожаловать на главную страницу! Выберите свою роль, кликнув на нужную кнопку ниже",
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                Margin = new Thickness(0, 10),
                TextColor = Color.Black 
            };
            Button userButton = new Button
            {
                Text = "User",
                BackgroundColor = Color.HotPink, 
                TextColor = Color.White, 
                Margin = new Thickness(0, 20, 0, 10)
            };
            Button adminButton = new Button
            {
                Text = "Admin",
                BackgroundColor = Color.Goldenrod, 
                TextColor = Color.White, 
                Margin = new Thickness(0, 10)
            };
            Button supportButton = new Button
            {
                Text = "Support",
                BackgroundColor = Color.LightSeaGreen, 
                TextColor = Color.White, 
                Margin = new Thickness(0, 10)
            };

            userButton.Clicked += UserButton_Clicked;
            adminButton.Clicked += AdminButton_Clicked;
            supportButton.Clicked += SupportButton_Clicked;

            Image image = new Image
            {
                Source = ImageSource.FromUri(new Uri("https://sun6-23.userapi.com/s/v1/if1/SShd77VpEL6orN0b7Q6h08UDBUCrvpbL_LpUOFmxiPa8SMEqbUQu5HA03elfE8WgB1nqSwtt.jpg?size=1000x1000&quality=96&crop=0,0,1000,1000&ava=1")), 
                Aspect = Aspect.AspectFill, 
                Margin = new Thickness(0, 20)
            };
            Content = new ScrollView
            {
                Content = new StackLayout
                {
                    BackgroundColor = Color.White, 
                    Padding = new Thickness(10, 40, 10, 10),
                    Children =
                    {
                        Header,
                        label1,
                        userButton,
                        adminButton,
                        supportButton,
                        image
                    }
                }
            };
        }

        private async void UserButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UserPage());
        }


        private async void AdminButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AdminPage());
        }

        private async void SupportButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SupportPage());
        }
    }
}