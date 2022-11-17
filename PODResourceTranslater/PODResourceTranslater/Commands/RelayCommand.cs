using System;

namespace PODResourceTranslater.Commands
{
    /// <summary>
    /// Ein Command
    /// </summary>
    public sealed class RelayCommand : BaseCommand
    {
        private readonly Action _methodToExecute;
        private readonly Func<bool> _canExecuteEvaluator;

        /// <summary>
        /// Ein Command
        /// </summary>
        /// <param name="methodToExecute">Methode die Ausgeführt wird</param>
        /// <param name="canExecuteEvaluator">Methode die Angibt ob das Ausführen möglich ist</param>
        public RelayCommand(Action methodToExecute, Func<bool> canExecuteEvaluator)
        {
            this._methodToExecute = methodToExecute;
            this._canExecuteEvaluator = canExecuteEvaluator;
        }

        /// <summary>
        /// Ein Command
        /// </summary>
        /// <param name="methodToExecute">Methode die Ausgeführt wird</param>
        public RelayCommand(Action methodToExecute)
            : this(methodToExecute, null)
        {
        }

        /// <summary>
        /// Methode die Angibt ob das Ausführen möglich ist
        /// </summary>
        /// <param name="parameter">Wird nicht verwendet default = <see langword="null"/></param>
        /// <returns><see langword="true"/> wenn Ausführen möglich ist</returns>
        public override bool CanExecute(object parameter = null)
        {
            return this._canExecuteEvaluator == null || this._canExecuteEvaluator.Invoke();
        }

        /// <summary>
        /// Methode die Ausgeführt wird
        /// </summary>
        /// <param name="parameter">Wird nicht verwendet default = <see langword="null"/></param>
        public override void Execute(object parameter = null)
        {
            this._methodToExecute.Invoke();
        }
    }
}