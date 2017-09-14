using System.Net.Http;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Microsoft.Extensions.DependencyInjection;
using NewYorkWeather.Services;
using NewYorkWeather.Services.WeatherService;
using Xamarin.Android.Net;

namespace NewYorkWeather.Droid
{
	[Activity (Label = "NewYorkWeather", Icon = "@drawable/icon", Theme="@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar; 

			base.OnCreate (bundle);

		    global::Xamarin.Forms.Forms.Init(this, bundle);

		    var currentPageService = new CurrentPageService();
		    Startup.AddServices(services =>
		    {
		        services.AddTransient<HttpMessageHandler, AndroidClientHandler>();
		        services.AddTransient<IWeatherService, WeatherService>();
		        services.AddTransient(p => currentPageService);
		        services.AddTransient<IDialogService, DialogService>();
		        services.AddViewModels();
		    });
		    var application = new App();
		    currentPageService.CurrentPage = application.MainPage;

		    LoadApplication(application);
        }
	}
}

