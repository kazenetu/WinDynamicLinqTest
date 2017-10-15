namespace WinDynamicLinqTest.Interfaces
{
    /// <summary>
    /// 入力コントロール用データソース取得インターフェース
    /// </summary>
    public interface ISettingControlDataSource

    {
        /// <summary>
        /// 選択値を取得
        /// </summary>
        /// <returns></returns>
        dynamic GetItem();

        /// <summary>
        /// 表示プロパティ名
        /// </summary>
        /// <returns></returns>
        string GetDisplayMember();

        /// <summary>
        /// 設定値プロパティ名
        /// </summary>
        /// <returns></returns>
        string GetValueMember();

    }
}
