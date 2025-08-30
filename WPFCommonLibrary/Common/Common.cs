using Microsoft.WindowsAPICodePack.Dialogs;
using Ookii.Dialogs.Wpf;

namespace WPFCommonLibrary.Common
{
    /// <summary>
    /// 共通クラス
    /// </summary>
    public class Common
    {
        /// <summary>
        /// フォルダ選択ダイアログ
        /// </summary>
        /// <returns>
        /// 成功：選択フォルダパス<br/>
        /// 失敗：空文字
        /// </returns>
        [Obsolete ( "" )]
        public static string OpenDirectorySelectDialog ()
        {
            VistaFolderBrowserDialog dialog = new VistaFolderBrowserDialog ()
            {
                Description = Properties.Resources.DirectorySelectDialogTitle,
                UseDescriptionForTitle = true,
            };

            string selectedDirectoryPath = string.Empty;

            if ( dialog.ShowDialog () ?? false )
            {
                selectedDirectoryPath = dialog.SelectedPath;
            }

            return selectedDirectoryPath;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="isMultiselect"></param>
        /// <returns></returns>
        [Obsolete ( "" )]
        public static IEnumerable<string> OpenFileSelectDialog ( string filter = "テキスト ファイル (*.txt)|*.txt|すべてのファイル (*.*)|*.*" , bool isMultiselect = false )
        {
            VistaFileDialog dialog = new VistaOpenFileDialog ()
            {
                Title = Properties.Resources.FileSelectedDialogTitle,
                Filter = filter,
                Multiselect = isMultiselect
            };

            IEnumerable<string> selectedFilePath = new List<string> ();
            if ( dialog.ShowDialog () ?? false )
            {
                selectedFilePath = dialog.FileNames;
            }

            return selectedFilePath;
        }

        /// <summary>
        /// ディレクトリパス取得
        /// </summary>
        /// <returns>ディレクトリパス</returns>
        public static string GetDirectoryPath ()
        {
            string directoryPath = string.Empty;

            CommonOpenFileDialog dialog = new CommonOpenFileDialog
            {
                Title = "フォルダを選択してください",
                IsFolderPicker = true,
            };

            if ( CommonFileDialogResult.Ok == dialog.ShowDialog () )
            {
                directoryPath = dialog.FileName;
            }

            return directoryPath;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="isMultiselect"></param>
        /// <returns></returns>
        public static IEnumerable<string> GetFilePaths ( Dictionary<string , string> filter , bool isMultiselect = false )
        {
            List<string> filePaths = new List<string> ();
            CommonOpenFileDialog dialog = new CommonOpenFileDialog
            {
                Title = "ファイルを選択してください",
                Filters = { new CommonFileDialogFilter ( "All Files", "*"  ) },
                IsFolderPicker = false,
                Multiselect = isMultiselect
            };

            foreach ( KeyValuePair<string , string> item in filter )
            {
                dialog.Filters.Add ( new CommonFileDialogFilter ( item.Key , item.Value ) );
            }

            if ( CommonFileDialogResult.Ok == dialog.ShowDialog () )
            {
                filePaths.AddRange ( dialog.FileNames );
            }
            return filePaths;
        }
    }
}
