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
    public partial class CCBLesson1 : ContentPage
    {
        public CCBLesson1()
        {
            InitializeComponent();
            videoWebView1.Source = "https://www.youtube.com/embed/s0HyE5CiiM8";
        }
    }
}