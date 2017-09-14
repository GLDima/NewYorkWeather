using Xamarin.Forms;

namespace NewYorkWeather.UI
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = ViewModelLocator.MainViewModel;
        }
    }
}