using RegressBioA.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RegressBioA.Commands
{
    /// <summary>
    /// Defines a command that executes an async operation, while conforming to the ICommand interface.
    /// </summary>
    /// <remarks>Designed to avoid using async void that swallows exceptions.</remarks>
    public abstract class AsyncCommandBase : ICommand
    {
        private bool _isExecuting;
        private readonly IErrorHandler _errorHandler;

        // TODO add proper summary when linter is in.
        public AsyncCommandBase(IErrorHandler errorHandler)
        {
            _errorHandler = errorHandler;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the command is currently executing.
        /// </summary>
        public bool IsExecuting
        {
            get => _isExecuting;
            private set
            {
                _isExecuting = value;
                CanExecuteChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        /// <inheritdoc/>
        public event EventHandler? CanExecuteChanged;

        /// <summary>
        /// Raises the <see cref="CanExecuteChanged"/> event, signalling that the ability of the command to execute has changed.
        /// </summary>
        public void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        /// <inheritdoc/>
        public bool CanExecute(object? parameter)
        {
            return !_isExecuting && CanExecuteCustom(parameter);
        }

        /// <summary>
        ///     Method that uses custom logic to determine whether the command should be able to execute,
        ///     on top of the default required logic to prevent further execution during async operation.
        /// </summary>
        /// <param name="parameter">
        ///     Data used by the command. If the command does not require
        ///     data to be passed this object can be set to null.</param>
        /// <returns>true if this command can be executed; otherwise, false</returns>
        public virtual bool CanExecuteCustom(object? parameter)
        {
            // default value
            return true;
        }

        /// <inheritdoc/>
        public void Execute(object? parameter)
        {
            ExecuteAsyncInternal(parameter).FireAndForgetSafeAsync(_errorHandler);
        }

        // Calls the implementation of the asnyc execution method defined in the command.
        private async Task ExecuteAsyncInternal(object? parameter)
        {
            try
            {
                IsExecuting = true;
                await ExecuteAsync(parameter);
            }
            finally
            {
                IsExecuting = false;
            }
        }

        /// <summary>
        ///     Executes the command asynchronously. This method should not be called - instead provide an async
        ///     implementation and call Execute.
        /// </summary>
        /// <param name="parameter">
        ///     Data used by the command. If the command does not require
        ///     data to be passed this object can be set to null.</param>
        /// <returns>A <see cref="Task"/> representing the asnyc operation to be started by the command.</returns>
        public abstract Task ExecuteAsync(object? parameter);
    }
}
