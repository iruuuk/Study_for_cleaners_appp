using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StudyForCleaners
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuestionPage : ContentPage
    {
        private bool isMenuVisible = false;

        public QuestionPage()
        {
            InitializeComponent();

            var navigationIcon = new ToolbarItem
            {
                IconImageSource = "https://upload.wikimedia.org/wikipedia/commons/thumb/b/b2/Hamburger_icon.svg/2048px-Hamburger_icon.svg.png",
                Priority = 0,
                Order = ToolbarItemOrder.Primary
            };
            navigationIcon.Clicked += (sender, e) =>
            {
                isMenuVisible = !isMenuVisible;
                UpdateMenuVisibility();
            };

            ToolbarItems.Add(navigationIcon);
            UpdateMenuVisibility();
        }

        private void UpdateMenuVisibility()
        {
            navigationMenu.IsVisible = isMenuVisible;
            profile.IsVisible = !isMenuVisible;

            if (isMenuVisible)
            {
                navigationMenu.HorizontalOptions = LayoutOptions.EndAndExpand;
                navigationMenu.Padding = new Thickness(0, -10, 0, 0); 
            }
            else
            {
                navigationMenu.HorizontalOptions = LayoutOptions.End;
                navigationMenu.Padding = new Thickness(0); 
            }
        }

        private async void OnProfileClicked(object sender, EventArgs e)
        {
            isMenuVisible = false;
            UpdateMenuVisibility();
            await Navigation.PushAsync(new UserPage());
        }

        private async void OnMyCoursesClicked(object sender, EventArgs e)
        {
            isMenuVisible = false;
            UpdateMenuVisibility();
            await Navigation.PushAsync(new MyCoursesPage());
        }

        private async void OnTimetableClicked(object sender, EventArgs e)
        {
            isMenuVisible = false;
            UpdateMenuVisibility();
            await Navigation.PushAsync(new TimetablePage());
        }

        private async void OnQuestionClicked(object sender, EventArgs e)
        {
            isMenuVisible = false;
            UpdateMenuVisibility();
            await Navigation.PushAsync(new QuestionPage());
        }

        private async void OnSendQuestionClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(questionEntry.Text))
            {
                errorLabel.IsVisible = true;
                return;
            }

            questionEntry.Text = string.Empty;
            errorLabel.IsVisible = false;

            await DisplayAlert("Спасибо за ваш вопрос!", "Ожидайте ответа от службы поддержки.", "OK");
        }
    }
}