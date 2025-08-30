using System.ComponentModel;

namespace WPFCommonLibrary.ViewModelBase
{
    /// <summary>
    /// ViewModelBaseクラス
    /// </summary>
    public class ViewModelBase : INotifyPropertyChanged
    {
        /// <summary>
        /// イベントハンドラー
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// プロパティ更新
        /// </summary>
        /// <param name="propertyName"></param>
        public void RaisePropertyChanged ( string propertyName )
        {
            if ( PropertyChanged != null )
                PropertyChanged ( this , new PropertyChangedEventArgs ( propertyName ) );
        }
    }
}
