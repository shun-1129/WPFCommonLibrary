namespace WPFCommonLibrary.Common
{
    /// <summary>
    /// 結果情報を保持するクラス
    /// </summary>
    public class Result
    {
        #region メンバ変数
        /// <summary>
        /// ステータス
        /// </summary>
        private bool _status = false;
        /// <summary>
        /// メッセージ
        /// </summary>
        private string _message = string.Empty;
        #endregion

        #region プロパティ
        /// <summary>
        /// ステータス
        /// </summary>
        public bool Status { get => _status; }
        /// <summary>
        /// メッセージ
        /// </summary>
        public string Message { get => _message; }
        #endregion

        #region コンストラクタ
        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public Result ()
        {
            _status = false;
            _message = string.Empty;
        }
        #endregion

        #region 内部メソッド
        #endregion

        #region 公開メソッド
        /// <summary>
        /// 成功
        /// </summary>
        public void Success ()
        {
            _status = false;
            _message = string.Empty;
        }

        /// <summary>
        /// 失敗
        /// </summary>
        /// <param name="message">メッセージ</param>
        public void Failure ( string message )
        {
            _status = true;
            _message = message;
        }
        #endregion
    }

    /// <summary>
    /// 結果情報を保持するクラス
    /// </summary>
    /// <typeparam name="T">結果情報と共に保持したいデータのクラスを指定</typeparam>
    public class Result<T>
    {
        #region メンバ変数
        /// <summary>
        /// 成否
        /// </summary>
        private bool _status = false;
        /// <summary>
        /// メッセージ内容
        /// </summary>
        private string _message = string.Empty;
        /// <summary>
        /// ジェネリック
        /// </summary>
        private T? _data;
        #endregion

        #region プロパティ
        /// <summary>
        /// 成功／失敗
        /// </summary>
        public bool Status { get => _status; }

        /// <summary>
        /// メッセージ
        /// </summary>
        public string Message { get => _message; }

        /// <summary>
        /// データ
        /// </summary>
        public T? Data { get => _data; }
        #endregion

        #region コンストラクタ
        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public Result ()
        {
            _status = false;
            _message = string.Empty;
            _data = default;
        }
        #endregion

        #region 公開メソッド
        /// <summary>
        /// 成功
        /// </summary>
        /// <param name="data">データ</param>
        public void Success ( T? data )
        {
            _status = false;
            _message = string.Empty;
            _data = data;
        }

        /// <summary>
        /// 失敗
        /// </summary>
        /// <param name="message">メッセージ</param>
        public void Failure ( string message )
        {
            _status = true;
            _message = message;
            _data = default;
        }
        #endregion

        #region 内部メソッド
        #endregion
    }
}
