namespace WPFCommonLibrary.Common.Data
{
    /// <summary>
    /// 各種データ
    /// </summary>
    public class Data
    {
        /// <summary>
        /// 容量単位を表す定義
        /// </summary>
        public enum SizeUnit
        {
            /// <summary>
            /// バイト
            /// </summary>
            Bytes = 1,
            /// <summary>
            /// キロバイト
            /// </summary>
            Kilobytes = 1024,
            /// <summary>
            /// メガバイト
            /// </summary>
            Megabytes = 1024 * 1024,
            /// <summary>
            /// ギガバイト
            /// </summary>
            Gigabytes = 1024 * 1024 * 1024
        }
    }
}
