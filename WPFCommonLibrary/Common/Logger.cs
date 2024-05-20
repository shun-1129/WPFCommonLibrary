namespace WPFCommonLibrary.Common
{
    public class Logger
    {
        #region メンバ変数
        /// <summary>
        /// NLogロガー
        /// </summary>
        private NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();
        #endregion

        #region プロパティ
        #endregion

        #region コンストラクタ
        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public Logger() { }
        #endregion

        #region publicメソッド
        /// <summary>
        /// Informationレベル
        /// </summary>
        /// <remarks>
        /// Informationレベルでログを出力する。
        /// </remarks>
        /// <param name="message">メッセージ</param>
        public void Info(string message)
        { 
            _logger.Info(message);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public void Warn(string message)
        {
            _logger.Warn(message);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public void Error(string message)
        {
            _logger.Error(message);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="message"></param>
        public void Error(Exception exception, string message)
        {
            _logger.Error(exception, message);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public void Fatal(string message)
        {
            _logger.Fatal(message);
        }
        #endregion

        #region privateメソッド
        #endregion
    }
}
