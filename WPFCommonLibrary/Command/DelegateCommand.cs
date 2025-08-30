using System.Windows.Input;

namespace WPFCommonLibrary.Command
{
    /// <summary>
    /// デリゲートコマンドクラス
    /// </summary>
    public class DelegateCommand : ICommand
    {
        /// <summary>
        /// イベントハンドラー
        /// </summary>
        public event EventHandler? CanExecuteChanged;

        private readonly Action _action;
        private readonly Func<bool>? _canExecute;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="action"></param>
        /// <param name="canExecute"></param>
        public DelegateCommand ( Action action , Func<bool>? canExecute = null )
        {
            this._action = action;
            this._canExecute = canExecute;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute ( object? parameter )
        {
            return _canExecute?.Invoke () ?? true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute ( object? parameter )
        {
            _action?.Invoke ();
        }

        /// <summary>
        /// 
        /// </summary>
        public void DelegateCanExecute ()
        {
            CanExecuteChanged?.Invoke ( this , EventArgs.Empty );
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DelegateCommand<T> : ICommand
    {
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler? CanExecuteChanged;

        private readonly Action<T> _action;
        private readonly Func<T, bool>? _canExecute;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="action"></param>
        /// <param name="canExecute"></param>
        public DelegateCommand ( Action<T> action , Func<T , bool>? canExecute = null )
        {
            this._action = action;
            this._canExecute = canExecute;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute ( object? parameter )
        {
            return _canExecute?.Invoke ( ( T ) parameter! ) ?? true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute ( object? parameter )
        {
            _action?.Invoke ( ( T ) parameter! );
        }

        /// <summary>
        /// 
        /// </summary>
        public void DelegateCanExecute ()
        {
            CanExecuteChanged?.Invoke ( this , EventArgs.Empty );
        }
    }
}
