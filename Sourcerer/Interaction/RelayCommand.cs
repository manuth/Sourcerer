using System;
using System.Windows.Input;

namespace Gizmo.Sourcerer.Interaction
{
    /// <summary>
    /// Provides <see langword="abstract"/> command for view-models.
    /// </summary>
    /// <typeparam name="T">The type of the command-parameter.</typeparam>
    public class RelayCommand<T> : ICommand
    {
        /// <summary>
        /// An action for executing the command.
        /// </summary>
        private Action<T> executor;

        /// <summary>
        /// A function for checking the availability of the command.
        /// </summary>
        private Func<T, bool> availabilityChecker = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="RelayCommand{T}"/> class.
        /// </summary>
        /// <param name="executor">The action to execute.</param>
        public RelayCommand(Action<T> executor)
        {
            this.executor = executor;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RelayCommand{T}"/> class.
        /// </summary>
        /// <param name="executor">The action to execute.</param>
        /// <param name="availabilityChecker">A function for checking the availability of the command.</param>
        public RelayCommand(Action<T> executor, Func<T, bool> availabilityChecker) : this(executor)
        {
            this.availabilityChecker = availabilityChecker;
        }

        /// <inheritdoc/>
        public event EventHandler CanExecuteChanged;

        /// <inheritdoc/>
        public bool CanExecute(object parameter)
        {
            if (availabilityChecker == null)
            {
                return true;
            }
            else
            {
                return availabilityChecker((T)parameter);
            }
        }

        /// <inheritdoc/>
        public void Execute(object parameter)
        {
            executor((T)parameter);
        }
    }
}
