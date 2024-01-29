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
    public partial class AnswersPage : ContentPage
    {
        public AnswersPage()
        {
            InitializeComponent();
        }

        private async void SendAnswerButton_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int questionNumber = Convert.ToInt32(button.CommandParameter);

            Entry answerEntry;
            switch (questionNumber)
            {
                case 1:
                    answerEntry = answer1Entry;
                    break;
                case 2:
                    answerEntry = answer2Entry;
                    break;
                case 3:
                    answerEntry = answer3Entry;
                    break;
                default:
                    return;
            }

            string answer = answerEntry.Text;

            if (string.IsNullOrEmpty(answer))
            {
                await DisplayAlert("Ошибка", "Введите ответ", "OK");
                return;
            }

            await SendAnswerToServer(questionNumber, answer);

            answerEntry.Text = string.Empty;

            await DisplayAlert("Успех", "Ответ успешно отправлен", "OK");
        }

        private async Task SendAnswerToServer(int questionNumber, string answer)
        {
        }
    }
}