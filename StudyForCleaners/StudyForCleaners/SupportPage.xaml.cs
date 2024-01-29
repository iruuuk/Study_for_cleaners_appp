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
    public partial class SupportPage : ContentPage
    {
        public SupportPage()
        {
            InitializeComponent();
        }

        private async void OnQuestionsDatabaseClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AnswersPage());
        }
    }
}