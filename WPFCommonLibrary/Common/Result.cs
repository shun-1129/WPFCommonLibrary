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
        public bool Status { get => _status; private set => _status = value; }
        /// <summary>
        /// メッセージ
        /// </summary>
        public string Message { get => _message; private set => _message = value; }
        #endregion

        #region コンストラクタ
        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public Result ()
        {
            Status = false;
            Message = string.Empty;
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
            Status = false;
            Message = string.Empty;
        }

        /// <summary>
        /// 失敗
        /// </summary>
        /// <param name="message">メッセージ</param>
        public void Failure ( string message )
        {
            Status = true;
            Message = message;
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
        public bool Status { get => _status; private set => _status = value; }

        /// <summary>
        /// メッセージ
        /// </summary>
        public string Message { get => _message; private set => _message = value; }

        /// <summary>
        /// データ
        /// </summary>
        public T? Data { get => _data; private set => _data = value; }
        #endregion

        #region コンストラクタ
        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public Result ()
        {
            Status = false;
            Message = string.Empty;
            Data = default;
        }
        #endregion

        #region 公開メソッド
        /// <summary>
        /// 成功
        /// </summary>
        /// <param name="data">データ</param>
        public void Success ( T? data )
        {
            Status = false;
            Message = string.Empty;
            Data = data;
        }

        /// <summary>
        /// 失敗
        /// </summary>
        /// <param name="message">メッセージ</param>
        public void Failure ( string message )
        {
            Status = true;
            Message = message;
            Data = default;
        }
        #endregion

        #region 内部メソッド
        #endregion
    }
}
