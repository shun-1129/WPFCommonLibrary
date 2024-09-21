namespace WPFCommonLibrary.Common
{
    public class FileConnection
    {
        #region 定数
        #endregion

        #region メンバ変数
        #endregion

        #region プロパティ
        #endregion

        #region コンストラクタ
        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public FileConnection () { }
        #endregion

        #region 公開メソッド
        #region staticメソッド
        /// <summary>
        /// ユーザディレクトリパス取得
        /// </summary>
        /// <returns>ユーザディレクトリパス</returns>
        public static string GetUserDirectory ()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        }

        /// <summary>
        /// 指定ディレクトリ存在確認
        /// </summary>
        /// <remarks>
        /// 処理内容:<br/>
        /// 1. 指定されたディレクトリが存在するか確認<br/>
        /// 2. 指定されたディレクトリが存在しないかつ、isCreateがtrueならディレクトリを作成
        /// </remarks>
        /// <param name="directoryPath">ディレクトリパス</param>
        /// <param name="isCreate">作成フラグ</param>
        /// <returns>結果情報</returns>
        public static Result<bool> IsDirectory ( string directoryPath, bool isCreate = false )
        {
            Result<bool> result = new Result<bool> ();

            try
            {
                if ( Directory.Exists ( directoryPath ) )
                {
                    result.Success ( true );
                }
                else if ( isCreate )
                {
                    Directory.CreateDirectory ( directoryPath );
                    result.Success ( true );
                }
                else
                {
                    result.Success ( false );
                }
            }
            catch ( Exception ex )
            {
                result.Failure ( $"エラー: {ex.Message}" );
            }

            return result;
        }

        /// <summary>
        /// ディレクトリからファイルを取得する
        /// </summary>
        /// <param name="directoryPath">ディレクトリパス</param>
        /// <param name="filter">フィルタ</param>
        /// <param name="isRecursive">再帰的検索</param>
        /// <returns>結果情報</returns>
        /// <exception cref="DirectoryNotFoundException"></exception>
        public static Result<List<string>> GetFilesFromDirectory ( string directoryPath , string filter = "*.*" , bool isRecursive = false )
        {
            // サーチオプション設定
            SearchOption searchOption = isRecursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;

            Result<List<string>> result = new Result<List<string>> ();

            try
            {
                // 指定したディレクトリが存在するか確認
                if ( !Directory.Exists ( directoryPath ) )
                {
                    throw new DirectoryNotFoundException ( $"指定されたディレクトリが見つかりません: {directoryPath}" );
                }

                // 指定したフィルタとサーチオプションに基づいてファイルを取得
                string[] files = Directory.GetFiles(directoryPath, filter, searchOption);

                result.Success ( new List<string> ( files ) );
                return result;
            }
            catch ( Exception ex )
            {
                // エラーが発生した場合に例外メッセージを表示
                result.Failure ( $"エラー: {ex.Message}" );
                return result;
            }
        }

        /// <summary>
        /// ファイル移動
        /// </summary>
        /// <remarks>
        /// 処理内容:<br/>
        /// 移動元ファイルが存在しない場合は、FileNotFoundExceptionをスロー。<br/>
        /// 移動先のフォルダが存在しない場合は、Directory.CreateDirectoryで作成。<br/>
        /// 移動先に同じ名前のファイルが既に存在する場合、ファイル名に現在の日付と時刻を付加。<br/>
        /// ファイルを移動して、移動先のファイルパスをコンソールに表示。<br/>
        /// 日付のフォーマット:<br/>
        /// ファイル名の末尾に yyyyMMdd_HHmmss 形式の日付と時刻が追加されます（例: file_20240922_123456.txt）。<br/>
        /// </remarks>
        /// <param name="sourceFilePath">移動元ファイルパス</param>
        /// <param name="destinationFolderPath">移動先フォルダパス</param>
        /// <returns>結果情報</returns>
        /// <exception cref="FileNotFoundException"></exception>
        public static Result MoveFileWithDateIfExists ( string sourceFilePath , string destinationFolderPath )
        {
            Result result = new Result ();

            try
            {
                // 移動元のファイルが存在するか確認
                if ( !File.Exists ( sourceFilePath ) )
                {
                    throw new FileNotFoundException ( $"指定されたファイルが見つかりません: {sourceFilePath}" );
                }

                // 移動先のフォルダが存在しない場合は作成
                if ( !Directory.Exists ( destinationFolderPath ) )
                {
                    Directory.CreateDirectory ( destinationFolderPath );
                }

                // ファイル名と拡張子を取得
                string fileName = Path.GetFileName(sourceFilePath);
                string destinationFilePath = Path.Combine(destinationFolderPath, fileName);

                // 同じ名前のファイルが存在する場合、日付を付けた新しい名前に変更
                if ( File.Exists ( destinationFilePath ) )
                {
                    string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(sourceFilePath);
                    string extension = Path.GetExtension(sourceFilePath);
                    string dateSuffix = DateTime.Now.ToString("yyyyMMdd_HHmmss"); // 日付フォーマット (例: 20240922_123456)
                    string newFileName = $"{fileNameWithoutExtension}_{dateSuffix}{extension}";
                    destinationFilePath = Path.Combine ( destinationFolderPath , newFileName );
                }

                // ファイルを移動
                File.Move ( sourceFilePath , destinationFilePath );

                result.Success ();
            }
            catch ( Exception ex )
            {
                result.Failure ( $"エラー: {ex.Message}" );
            }

            return result;
        }

        /// <summary>
        /// 指定されたフォルダの容量が指定した容量以上か以下かを確認
        /// </summary>
        /// <remarks>
        /// 処理内容:<br/>
        /// 指定されたフォルダが存在するかどうかを確認します。<br/>
        /// フォルダ内のすべてのファイルのサイズを合計します（サブフォルダ内のファイルも含む）。<br/>
        /// フラグに応じて、フォルダの総容量が指定された容量よりも「以上」か「以下」かを判定します。<br/>
        /// </remarks>
        /// <param name="directoryPath">ディレクトリパス</param>
        /// <param name="sizeInBytes">容量</param>
        /// <param name="checkIfExceeds">trueなら容量以上かをチェック、falseなら容量以下かをチェック</param>
        /// <returns>結果情報</returns>
        /// <exception cref="DirectoryNotFoundException"></exception>
        public static Result<bool> CheckFolderSize ( string directoryPath , long sizeInBytes , bool checkIfExceeds )
        {
            Result<bool> result = new Result<bool> ();

            try
            {
                // 指定されたフォルダが存在するか確認
                if ( !Directory.Exists ( directoryPath ) )
                {
                    throw new DirectoryNotFoundException ( $"指定されたフォルダが見つかりません: {directoryPath}" );
                }

                // フォルダ内の全ファイルサイズを取得
                long folderSize = GetDirectorySize(directoryPath);

                // フォルダの容量を指定された容量と比較
                if ( checkIfExceeds )
                {
                    // 容量が指定サイズ以上かを確認
                    result.Success ( folderSize >= sizeInBytes );
                }
                else
                {
                    // 容量が指定サイズ以下かを確認
                    result.Success ( folderSize <= sizeInBytes );
                }
            }
            catch ( Exception ex )
            {
                result.Failure ( $"エラー: {ex.Message}" );
            }

            return result;
        }
        #endregion
        #endregion

        #region 内部メソッド
        #region staticメソッド
        /// <summary>
        /// 指定したフォルダ内のファイルの総サイズを計算
        /// </summary>
        /// <param name="directoryPath">ディレクトリパス</param>
        /// <returns>総ファイルサイズ</returns>
        private static long GetDirectorySize ( string directoryPath )
        {
            long totalSize = 0;

            // フォルダ内のすべてのファイルのサイズを合計
            string[] files = Directory.GetFiles( directoryPath, "*.*", SearchOption.AllDirectories );
            foreach ( string file in files )
            {
                FileInfo fileInfo = new FileInfo(file);
                totalSize += fileInfo.Length;
            }

            return totalSize;
        }
        #endregion
        #endregion
    }
}
