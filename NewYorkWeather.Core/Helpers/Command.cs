using System;
using System.Windows.Input;

namespace NewYorkWeather.Helpers
{
	/// <summary>
    /// Defines an <see cref="T:System.Windows.Input.ICommand" /> implementation
    /// </summary>
	public class Command : ICommand
    {
        private readonly Func<object, bool> _canExecute;
        private readonly Action<object> _execute;

        public Command(Action<object> execute)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
        }
        public Command(Action<object> execute, Func<object, bool> canExecute)
          : this(execute)
        {
            _canExecute = canExecute ?? throw new ArgumentNullException(nameof(canExecute));
        }

        /// <summary>
        /// Execute command with the specified parameter.
        /// </summary>
        /// <param name="parameter">Parameter for the command.</param>
        public void Execute(object parameter)
        {
            _execute(parameter);
        }
		/// <summary>
		/// Returns <c>true</c>, if command can be executed with supplied parameter, <c>false</c> otherwise.
		/// </summary>
		/// <param name="parameter">Parameter for the command.</param>
		public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }
		/// <summary>
		/// Raise <c>CanExecuteChanged</c> event.
		/// </summary>
		public void ChangeCanExecute()
        {
            var canExecuteChanged = CanExecuteChanged;
            canExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
        /// <summary>
        /// Occurs when command changed a condition for execution.
        /// </summary>
		public event EventHandler CanExecuteChanged;
    }
}