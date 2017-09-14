using System.Net.Http;
using Foundation;
using Microsoft.Extensions.DependencyInjection;
using NewYorkWeather.Services;
using NewYorkWeather.Services.WeatherService;
using UIKit;

namespace NewYorkWeather.iOS
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the 
	// User Interface of the application, as well as listening (and optionally responding) to 
	// application events from iOS.
	[Register("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		//
		// This method is invoked when the application has loaded and is ready to run. In this 
		// method you should instantiate the window, load the UI into it and then make the window
		// visible.
		//
		// You have 17 seconds to return from this method, or iOS will terminate your application.
		//
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
		    global::Xamarin.Forms.Forms.Init();
#if ENABLE_TEST_CLOUD
			Xamarin.Calabash.Start();
#endif
			var currentPageService = new CurrentPageService();
            Startup.AddServices(services =>
		    {
                services.AddTransient<HttpMessageHandler, NSUrlSessionHandler>();
		        services.AddTransient<IWeatherService, WeatherService>();
		        services.AddTransient(p => currentPageService);
		        services.AddTransient<IDialogService, DialogService>();
		        services.AddViewModels();
            });
		    var application = new App();
		    currentPageService.CurrentPage = application.MainPage;

            LoadApplication (application);

			return base.FinishedLaunching (app, options);
		}
	}
}
