# NewYorkWeather
Demo project for second challenge - Consuming external APIs in Xamarin apps and Xamarin.UITest.

This Xamarin mobile application retrieves weather information from a RESTful weather API, and display it in a dialog. This project targets Android and  iOS using Xamarin.Forms.

Solution contains:
- NewYorkWeather.Droid project for Android startup.
- NewYorkWeather.iOS project for iOS statrup.
- NewYorkWeather.UI shared project with Xamarin.Forms pages and common UI  logic.
- NewYorkWeather.Core is DotNetStandard library with  RESTful API interaction logic.
- NewYorkWeather.UITests project with UI tests for Xamarin.Forms pages.

NewYorkWeather.UITests has a set of cross-platform tests in a "Test" class. They will be run against both platforms. You could use Visual Studio Unit Tests Runner to run them.

![screenshot](https://raw.githubusercontent.com/GLDima/NewYorkWeather/master/screenshots/TestRuner.png "Test hierarchy")
