namespace WPFCommonLibrary.Common
{
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

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="inStatus">ステータス</param>
        /// <param name="inMessage">メッセージ</param>
        public Result ( bool inStatus , string inMessage )
        {
            Status = inStatus;
            Message = inMessage;
        }
        #endregion

        #region 内部メソッド
        #endregion

        #region 公開メソッド
        /// <summary>
        /// 成功
        /// </summary>
        /// <returns>リザルト</returns>
        public Result Success ()
        {
            return new Result ();
        }
        #endregion
    }
}
