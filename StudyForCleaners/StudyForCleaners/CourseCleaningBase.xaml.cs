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
    public partial class CourseCleaningBase : ContentPage
    {
        public CourseCleaningBase()
        {
            InitializeComponent();
        }

        private async void Lesson1Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CCBLesson1());
        }

        private async void Lesson2Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CCBLesson2());
        }
    }
}