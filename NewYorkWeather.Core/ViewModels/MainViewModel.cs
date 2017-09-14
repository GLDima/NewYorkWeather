using System;
using System.Windows.Input;
using NewYorkWeather.Helpers;
using NewYorkWeather.Services;
using NewYorkWeather.Services.WeatherService;

namespace NewYorkWeather.ViewModels
{
    /// <summary>
    /// View model for Main Screen.
    /// </summary>
    public class MainViewModel: BaseViewModel
    {
        private readonly IDialogService _dialogService;
        private readonly IWeatherService _weatherService;

        /// <summary>
        /// Retrieves weather report in a dialog.
        /// </summary>
        /// <value>The retrieve wether command.</value>
        public Command RetrieveWetherCommand { get; }
        
        private async void RetrieveWether()
        {
            try
            {
                IsBusy = true;
                RetrieveWetherCommand.ChangeCanExecute();

                var report = await _weatherService.GetNYWeatherReportAsync(DateTime.Today);

                await _dialogService.AlertAsync(report, "Weather report");
            }
            catch (WeatherClientException e)
            {
                await _dialogService.AlertAsync("Some problems with Wunderground service", "Error");
            }
            catch (Exception e)
            {
                await _dialogService.AlertAsync("Unknown error", "Error");
            }
            finally
            {
                IsBusy = false;
                RetrieveWetherCommand.ChangeCanExecute();
            }            
        }
        private bool CanRetrieveWether()
        {
            return !IsBusy;
        }

        public MainViewModel(IDialogService dialogService, IWeatherService weatherService)
        {
            _dialogService = dialogService;
            _weatherService = weatherService;

            RetrieveWetherCommand = new Command(_ => RetrieveWether(), p => CanRetrieveWether());
        }
    }

}
