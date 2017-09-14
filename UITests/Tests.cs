using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace NewYorkWeather.UITests
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class Tests
    {
        private IApp _app;
        private Platform _platform;

        private AppResult[] WaitForMainScreen()
        {
			return _app.WaitForElement(c => c.Button("WeatherNYToday"));
		}

        public Tests(Platform platform)
        {
            _platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            _app = AppInitializer.StartApp(_platform);
        }

		[Test]
		public void WeatherNYTodayButtonIsDisplayedOnMainScreen()
		{
            AppResult[] results = WaitForMainScreen();
			_app.Screenshot("Main screen.");

            Assert.IsTrue(results.Length == 1, "Main screen contains 'Weather In New York Today' button");
		}

        [Test]
        public void WeatherReportDialogAppearsWhenWeatherNYTodayButtonPressed()
        {
            WaitForMainScreen();
			_app.Tap("WeatherNYToday");
            var results = _app.WaitForElement(c => c.Text("Weather report"));
            _app.Screenshot("Weather report dialog.");

            Assert.IsTrue(results.Length == 1, "Dialog contains weather report");
        }

        [Test]
        public void WeatherReportDialogAppearsAgainAfterDismissingPreviousOne()
        {
			WaitForMainScreen();
			_app.Tap("WeatherNYToday");
            _app.WaitForElement(c => c.Text("Weather report"));
            _app.Tap("Cancel");
            WaitForMainScreen();
            _app.Tap("WeatherNYToday");
			var results = _app.WaitForElement(c => c.Text("Weather report"));

            Assert.IsTrue(results.Length == 1, "Dialog contains weather report");
        }
    }
}
