using System.ComponentModel;

namespace NewYorkWeather.ViewModels
{
    /// <summary>
    /// Base view model with IsBusy indicator.
    /// </summary>
    public class BaseViewModel : INotifyPropertyChanged
    {
        private bool _isBusy;

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:NewYorkWeather.ViewModels.BaseViewModel"/> is busy.
        /// </summary>
        /// <value><c>true</c> if is busy; otherwise, <c>false</c>.</value>
        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                if (_isBusy != value)
                {
                    _isBusy = value;
                    OnPropertyChanged(nameof(IsBusy));
                }
            }
        }

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Occurs when property changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
    }

}
