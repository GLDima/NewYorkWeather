using System.Threading.Tasks;

namespace NewYorkWeather.Services
{
    /// <summary>
    /// Dialog service.
    /// </summary>
    public interface IDialogService
    {
		/// <summary>
		/// Presents an alert dialog with a single cancel button.
		/// </summary>
		/// <param name="title">The title of the alert dialog.</param>
		/// <param name="message">The body text of the alert dialog.</param>
		Task AlertAsync(string message, string title);
    }
}
