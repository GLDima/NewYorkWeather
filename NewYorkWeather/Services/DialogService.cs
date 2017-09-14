using System;
using System.Threading.Tasks;

namespace NewYorkWeather.Services
{
    public class DialogService : IDialogService
    {
        private readonly CurrentPageService _pageService;

		public Task AlertAsync(string message, string title)
        {
            return _pageService.CurrentPage.DisplayAlert(title, message, "Cancel");
        }

        public DialogService(CurrentPageService pageService)
        {
            _pageService = pageService;
        }
    }
}