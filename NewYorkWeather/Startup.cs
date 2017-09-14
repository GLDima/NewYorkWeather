using System;
using Microsoft.Extensions.DependencyInjection;
using NewYorkWeather.Services;
using NewYorkWeather.ViewModels;

namespace NewYorkWeather
{
    /// <summary>
    /// Place for the services initialization.
    /// </summary>
    public sealed class Startup
    {
        private static IServiceProvider _provider;

        public static void AddServices(Action<IServiceCollection> add)
        {
            if (add == null)
                throw new ArgumentNullException(nameof(add));

            IServiceCollection services = new ServiceCollection();
            add(services);
            _provider = services.BuildServiceProvider();
        }
        public static TValue UseServices<TValue>(Func<IServiceProvider, TValue> use)
        {
            if (use == null)
                throw new ArgumentNullException(nameof(use));

            return use(_provider);
        }
    }

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddViewModels(this IServiceCollection services)
        {
            return services.AddTransient<MainViewModel>();
        }
    }

    public sealed class ViewModelLocator
    {
        public static MainViewModel MainViewModel =>
            Startup.UseServices(p => p.GetService<MainViewModel>());
    }
}