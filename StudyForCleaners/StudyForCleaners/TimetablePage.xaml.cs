using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StudyForCleaners
{
    public partial class TimetablePage : ContentPage
    {
        private StackLayout lessonEntryLayout;
        private bool isMenuVisible = false;

        public TimetablePage()
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
            profile.IsVisible = isMenuVisible;
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

        private void AddLessonButtonClicked(object sender, EventArgs e)
        {
            Entry courseEntry = new Entry
            {
                Placeholder = "Название курса",
                FontAttributes = FontAttributes.Bold,
                FontSize = 20
            };
            Entry lessonEntry = new Entry
            {
                Placeholder = "Название урока",
                FontAttributes = FontAttributes.Bold,
                FontSize = 20
            };
            DatePicker dateDatePicker = new DatePicker();
            TimePicker timePicker = new TimePicker();

            Button saveButton = new Button
            {
                Text = "Сохранить",
                FontSize = 20,
                FontAttributes = FontAttributes.Bold
            };
            saveButton.Clicked += (s, args) =>
            {
                SaveButtonClicked(courseEntry.Text, lessonEntry.Text, dateDatePicker.Date, timePicker.Time);
                mainStackLayout.Children.Remove(lessonEntryLayout);
            };

            lessonEntryLayout = new StackLayout
            {
                Children = {
                    new Label { Text = "Курс:", FontSize = 20, FontAttributes = FontAttributes.Bold },
                    courseEntry,
                    new Label { Text = "Урок:", FontSize = 20, FontAttributes = FontAttributes.Bold },
                    lessonEntry,
                    new Label { Text = "Дата дедлайна:", FontSize = 20, FontAttributes = FontAttributes.Bold },
                    dateDatePicker,
                    new Label { Text = "Время дедлайна:", FontSize = 20, FontAttributes = FontAttributes.Bold }, timePicker,
                    saveButton
},
                Margin = new Thickness(10)
            };

            mainStackLayout.Children.Add(lessonEntryLayout);
        }

        private void SaveButtonClicked(string course, string lesson, DateTime date, TimeSpan time)
        {
            DateTime reminderTime = date.Add(time).AddMinutes(-10); 

            Device.StartTimer(TimeSpan.FromMinutes(1), () =>
            {
                if (DateTime.Now >= reminderTime) 
                {
                    DisplayAlert("Напоминание", $"Не забудьте об уроке \"{lesson}\" в курсе \"{course}\"", "OK"); 
                    return false; 
                }
                return true; 
            });

            Label lessonLabel = new Label
            {
                Text = $"Курс: {course}\nУрок: {lesson}\nДата дедлайна: {date.ToString("dd.MM.yyyy")}\nВремя дедлайна: {time.ToString("hh\\:mm")}",
                Margin = new Thickness(0, 10, 0, 0),
                FontSize = 20,
                FontAttributes = FontAttributes.Bold
            };

            mainStackLayout.Children.Insert(mainStackLayout.Children.Count - 1, lessonLabel);
        }
    }
}