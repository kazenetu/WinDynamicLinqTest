namespace WinDynamicLinqTest.Interfaces
{
    /// <summary>
    /// ViewModelインターフェース
    /// </summary>
    public interface IViewModel
    {
        /// <summary>
        /// Modelインスタンスの取得
        /// </summary>
        /// <returns>IModelインスタンス</returns>
        IModel GetModel();

        /// <summary>
        /// プロパティ更新の通知
        /// </summary>
        /// <param name="propertyName">プロパティ名</param>
        void NotifyPropertyChanged(string propertyName);
    }
}
