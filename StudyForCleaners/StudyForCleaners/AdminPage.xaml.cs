using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StudyForCleaners
{
    public partial class AdminPage : ContentPage
    {
        public AdminPage()
        {
            InitializeComponent();
        }
        public class Course
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
        }

        private void AddCourseButton_Clicked(object sender, EventArgs e)
        {
            CourseFieldsLayout.IsVisible = true;
        }

        private void SaveCourseButton_Clicked(object sender, EventArgs e)
        {
            string courseName = CourseNameEntry.Text;
            string courseDescription = CourseDescriptionEntry.Text;
            DateTime startDate = StartDatePicker.Date;
            DateTime endDate = EndDatePicker.Date;

            Course newCourse = new Course
            {
                Name = courseName,
                Description = courseDescription,
                StartDate = startDate,
                EndDate = endDate
            };

            CourseNameEntry.Text = "";
            CourseDescriptionEntry.Text = "";
            StartDatePicker.Date = DateTime.Today;
            EndDatePicker.Date = DateTime.Today;

            CourseFieldsLayout.IsVisible = false;

            DisplayCourse(newCourse);
        }

        private void DisplayCourse(Course course)
        {
            Label nameLabel = new Label
            {
                Text = "''" + course.Name + "''",
                FontAttributes = FontAttributes.Bold
            };

            Label descriptionLabel = new Label
            {
                Text ="Описание: " + course.Description,
                FontAttributes = FontAttributes.Bold,
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label))
            };

            Label startDateLabel = new Label
            {
                Text = "Дата начала: " + course.StartDate.ToString("dd.MM.yyyy"),
                FontAttributes = FontAttributes.Bold
            };

            Label endDateLabel = new Label
            {
                Text = "Дата окончания: " + course.EndDate.ToString("dd.MM.yyyy"),
                FontAttributes = FontAttributes.Bold
            };

            Frame courseFrame = new Frame
            {
                Content = new StackLayout
                {
                    Children = { nameLabel, descriptionLabel, startDateLabel, endDateLabel }
                },
                BorderColor = Color.Black,
                Padding = new Thickness(10),
                Margin = new Thickness(0, 0, 0, 10)
            };

            CoursesStackLayout.Children.Add(courseFrame);
        }
    }
}